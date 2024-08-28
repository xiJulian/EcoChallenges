using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class SignUp : System.Web.UI.Page
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
      else
      {
        CityDropDownList.DataSource = service.GetAllCities();
        CityDropDownList.DataValueField = "name";
        CityDropDownList.DataTextField = "name";
        CityDropDownList.DataBind();
      }
    }

    protected void SignUpButton_Click(object sender, EventArgs e)
    {
      if (service.UserExists(EmailTextBox.Text))
      {
        ErrorLabel.Visible = true;
        ErrorLabel.Text = "A user with this email already exists!";
      }
      else
      {
        ErrorLabel.Visible = false;
        User user = new User();
        user.email = EmailTextBox.Text;
        user.firstName = FirstNameTextBox.Text;
        user.lastName = LastNameTextBox.Text;
        user.password = PasswordTextBox.Text;
        user.points = 0;
        user.city = service.GetCityByName(CityDropDownList.Text);
        int success = service.AddUser(user);

        if (success == 0)
        {
          ErrorLabel.Visible = true;
          ErrorLabel.Text = "Failed to register user.";
        }
        else
        {
          Session["email"] = EmailTextBox.Text;
          Session["password"] = PasswordTextBox.Text;
          Response.Redirect("Profile.aspx");
          // Response.Redirect("SignIn.aspx");
        }
      }
    }
  }
}