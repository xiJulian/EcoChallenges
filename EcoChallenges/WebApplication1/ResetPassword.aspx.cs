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
  public partial class ResetPassword : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ResetPasswordButton_Click(object sender, EventArgs e)
    {
      Service1Client service = new Service1Client();

      if (!service.UserExists(this.EmailTextBox.Text))
      {
        this.SuccessLabel.Visible = false;
        this.ErrorLabel.Visible = true;
        this.ErrorLabel.Text = "Email not found!";
      }
      else
      {
        this.ErrorLabel.Visible = false;
        this.SuccessLabel.Visible = true;
        this.SuccessLabel.Text = "Password: " + service.GetUserPassword(this.EmailTextBox.Text);
      }
    }
  }
}