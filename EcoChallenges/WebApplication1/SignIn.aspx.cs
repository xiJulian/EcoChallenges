using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class SignIn : System.Web.UI.Page
  {
    Service1Client service = new Service1Client();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["email"] != null)
      {
        if (service.UserExists(Session["email"].ToString()))
        {
          Response.Redirect("Default.aspx");
        }
      }
    }

    protected void SignInButton_Click(object sender, EventArgs e)
    {
      if (!service.UserExists(this.EmailTextBox.Text) || service.GetUserPassword(this.EmailTextBox.Text) != this.PasswordTextBox.Text)
      {
        this.ErrorLabel.Visible = true;
        this.ErrorLabel.Text = "User not found!";
      }
      else
      {
        this.ErrorLabel.Visible = false;
        Session["email"] = this.EmailTextBox.Text;
        Session["password"] = this.PasswordTextBox.Text;
        Response.Redirect("Profile.aspx");
      }
    }
  }
}