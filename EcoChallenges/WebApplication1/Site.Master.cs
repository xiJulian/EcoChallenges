using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class Site : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Service1Client service = new Service1Client();

        if (Session["email"] != null)
        {
          if (service.UserExists(Session["email"].ToString()) && Session["password"].ToString() == service.GetUserPassword(Session["email"].ToString()))
          {
            this.signInButton.Visible = false;
            this.profileButton.Visible = true;
            this.profileButton.Text += service.GetUserName(Session["email"].ToString());
          } else
        {
          Session["email"] = null;
          Session["password"] = null;
        }
        }
      }
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
      Session["email"] = null;
      Session["password"] = null;
      Response.Redirect(Request.Url.AbsoluteUri);
    }
  }
}