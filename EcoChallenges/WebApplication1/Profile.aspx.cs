using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class Profile : System.Web.UI.Page
  {
    Service1Client service = new Service1Client();

    protected void Page_Load(object sender, EventArgs e)
    {
      int userId;
      int.TryParse(Request.Params["id"], out userId);

      if (!IsPostBack)
      {
        User loggedUser = service.GetAllUsers().ToList().Find(item => Session["email"] != null && item.email == Session["email"].ToString());
        User publicUser = service.GetAllUsers().ToList().Find(item => item.id == userId);

        if (loggedUser != null && (Request.Params["id"] == null || userId == loggedUser.id))
        {
          userId = loggedUser.id;
          ShowProfile(loggedUser, true);
        }
        else if (publicUser != null) ShowProfile(publicUser, false);
        else Response.Redirect("Default.aspx");
      }
    }

    private void ShowProfile(User user, bool isLogged)
    {
      UserChallenge[] userChallenges = service.GetAllChallengesByUser(user.email);
      UsernameLabel.Text = user.firstName + " " + user.lastName;
      CityLabel.Text = user.city.name;
      ChallengesNumberLabel.Text = userChallenges.Count().ToString();
      UserPointsLabel.Text = user.points.ToString();
      ChallengeRepeater.DataSource = userChallenges;
      ChallengeRepeater.DataBind();
      if (isLogged)
      {
        UserEmailDiv.Visible = true;
        UserEmailLabel.Text = user.email;
        DeleteButtonDiv.Visible = true;
        changePassword.Visible = true;
        boxChangePassword.Visible = true;
      }
    }

    protected void SaveButton_Click(object sender, EventArgs e)
    {
      string password = service.GetUserPassword(Session["email"].ToString());
      if (OldPasswordTextBox.Text != password)
      {
        ActionLabel.Text = "The old password is wrong!";
        ActionLabel.ForeColor = Color.MediumVioletRed;
      }
      else if (NewPasswordTextBox.Text == password)
      {
        ActionLabel.Text = "The old and new password can't be the same!";
        ActionLabel.ForeColor = Color.MediumVioletRed;
      }
      else
      {
        service.SetUserPassword(Session["email"].ToString(), NewPasswordTextBox.Text);
        ActionLabel.Text = "Password changed successfully.";
        ActionLabel.ForeColor = Color.Green;
      }
    }

    protected void ChallengeRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        ((Label)e.Item.FindControl("ChallengeTitle")).Text = service.GetChallenge((int)DataBinder.Eval(e.Item.DataItem, "challengeId")).title;
        if ((bool)DataBinder.Eval(e.Item.DataItem, "isCompleted") == true)
          ((Label)e.Item.FindControl("ChallengeFinishedIn")).Text = "Finished in: " + DataBinder.Eval(e.Item.DataItem, "completedAt");
        else
          ((Label)e.Item.FindControl("ChallengeFinishedIn")).Text = "Not finished yet.";
      }
    }

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
      service.DeleteUser(Session["email"].ToString(), Session["password"].ToString());
    }
  }
}