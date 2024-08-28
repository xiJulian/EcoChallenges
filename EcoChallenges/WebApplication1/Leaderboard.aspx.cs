using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;
using System.Data;

namespace WebApplication
{
  public partial class Leaderboard : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Service1Client service = new Service1Client();
      LeaderboardGridView.DataSource = service.GetAllUsers().OrderByDescending(user => user.points).ToList();
      LeaderboardGridView.DataBind();
    }

    protected void LeaderboardGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();
        HyperLink link = new HyperLink();
        link.Text = DataBinder.Eval(e.Row.DataItem, "firstName") + " " + DataBinder.Eval(e.Row.DataItem, "lastName");
        link.NavigateUrl = "~/Profile.aspx?id=" + DataBinder.Eval(e.Row.DataItem, "id");
        e.Row.Cells[1].Controls.Add(link);
      }
    }
  }
}