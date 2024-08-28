using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class Contact : System.Web.UI.Page
  {
    Service1Client service = new Service1Client();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SendButton_Click(object sender, EventArgs e)
    {
      if (Session["email"] != null && service.UserExists(Session["email"].ToString()))
      {
        ServiceReference1.Message message = new ServiceReference1.Message();
        message.email = Session["email"].ToString();
        message.subject = SubjectTextBox.Text;
        message.content = BodyTextBox.Text;
        service.CreateMessage(message);
        ActionLabel.Text = "Message sent to admins successfully!";
        ActionLabel.ForeColor = Color.Green;
      }
      else
      {
        ActionLabel.Text = "You need to login first!";
        ActionLabel.ForeColor = Color.MediumVioletRed;
      }
    }
  }
}