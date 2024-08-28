using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class Challenge : System.Web.UI.Page
  {
    Service1Client service = new Service1Client();
    int challengeId;

    protected void Page_Load(object sender, EventArgs e)
    {
      int.TryParse(Request.Params["id"], out challengeId);

      if (!IsPostBack)
      {
        ServiceReference1.Challenge challenge = service.GetChallenge(challengeId);
        if (challenge == null)
        {
          Response.Redirect("Challenges.aspx");
        }
        else
        {
          ChallengeTitle.Text = challenge.title;
          ChallengeDescription.Text = challenge.description;
          ChallengeDate.Text += challenge.createdAt;
          ChallengePoints.Text = "+" + challenge.points + " points";

          TopUsersGridView.DataSource = service.GetAllCompletedChallenges(challengeId).OrderBy(item => getCompletedIn(item.startedAt, item.completedAt)).Take(6).ToList();
          TopUsersGridView.DataBind();

          CommentRepeater.DataSource = service.GetAllCompletedChallenges(challengeId).OrderByDescending(item => item.completedAt).ToList();
          CommentRepeater.DataBind();

          if (Session["email"] != null && service.UserExists(Session["email"].ToString()))
          {
            ServiceReference1.UserChallenge userChallenge = service.GetUserChallenge(challengeId, Session["email"].ToString());
            if (userChallenge != null)
            {
              UserProgressErrorLabel.Visible = false;
              StartButton.Visible = false;
              userProgressDetails.Visible = true;
              UserProgressStartedInLabel.Text += userChallenge.startedAt;

              if (userChallenge.isCompleted)
              {
                UserProgressFinishedInDiv.Visible = true;
                UserProgressFinishedInLabel.Text += userChallenge.completedAt;
                UserFinishedCommentDiv.Visible = true;
                UserFinishedComment.Text += userChallenge.comment;
              }
              else
              {
                FinishButtonDiv.Visible = true;
              }
            }
          }
          else
          {
            UserProgressErrorLabel.Text = "You need to login first.";
            UserProgressErrorLabel.ForeColor = Color.MediumVioletRed;
            StartButton.Visible = false;
          }
        }
      }
    }

    protected void TopUsersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        ServiceReference1.User user = service.GetAllUsers().ToList().Find(item => item.email == DataBinder.Eval(e.Row.DataItem, "userEmail").ToString());
        TimeSpan time = getCompletedIn(DataBinder.Eval(e.Row.DataItem, "startedAt").ToString(), DataBinder.Eval(e.Row.DataItem, "completedAt").ToString());
        e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();

        HyperLink link = new HyperLink();
        link.Text = user.firstName + " " + user.lastName;
        link.NavigateUrl = "~/Profile.aspx?id=" + user.id;
        e.Row.Cells[1].Controls.Add(link);

        e.Row.Cells[2].Text = string.Format("{0:D2} days, {1:D2} hours", time.Days, time.Hours);
      }
    }

    private TimeSpan getCompletedIn(string startedAt, string completedAt)
    {
      return DateTime.ParseExact(completedAt, "dd/MM/yyyy HH:mm", null) - DateTime.ParseExact(startedAt, "dd/MM/yyyy HH:mm", null);
    }

    protected void CommentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        ServiceReference1.User user = service.GetAllUsers().ToList().Find(item => item.email == DataBinder.Eval(e.Item.DataItem, "userEmail").ToString());
        ((HyperLink)e.Item.FindControl("CommentUsername")).Text = user.firstName + " " + user.lastName;
        ((HyperLink)e.Item.FindControl("CommentUsername")).NavigateUrl = "~/Profile.aspx?id=" + user.id;
      }
    }

    protected void StartButton_Click(object sender, EventArgs e)
    {
      ServiceReference1.UserChallenge userChallenge = new ServiceReference1.UserChallenge();
      userChallenge.challengeId = challengeId;
      userChallenge.userEmail = Session["email"].ToString();
      service.AddUserChallenge(userChallenge);
      ActionLabel.Text = "Challenge started.";
      ActionLabel.ForeColor = Color.Green;

      UserProgressErrorLabel.Visible = false;
      StartButton.Visible = false;
      userProgressDetails.Visible = true;
      UserProgressStartedInLabel.Text += DateTime.Now.ToString("dd/MM/yyyy HH:mm");
      FinishButtonDiv.Visible = true;
    }

    protected void FinishButton_Click(object sender, EventArgs e)
    {
      if (CommentTextBox.Text == null)
      {
        ActionLabel.Text = "You must provide a comment!";
        ActionLabel.ForeColor = Color.MediumVioletRed;
      }
      else
      {
        service.CompleteUserChallenge(challengeId, Session["email"].ToString(), CommentTextBox.Text);
        service.AddUserPoints(Session["email"].ToString(), service.GetChallenge(challengeId).points);
        ActionLabel.Text = "Challenge finished.";
        ActionLabel.ForeColor = Color.Green;

        FinishButtonDiv.Visible = false;
        UserProgressFinishedInDiv.Visible = true;
        UserProgressFinishedInLabel.Text += DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        UserFinishedCommentDiv.Visible = true;
        UserFinishedComment.Text += CommentTextBox.Text;

        TopUsersGridView.DataSource = service.GetAllCompletedChallenges(challengeId).OrderBy(item => getCompletedIn(item.startedAt, item.completedAt)).Take(6).ToList();
        TopUsersGridView.DataBind();

        CommentRepeater.DataSource = service.GetAllCompletedChallenges(challengeId).OrderByDescending(item => item.completedAt).ToList();
        CommentRepeater.DataBind();
      }
    }
  }
}
