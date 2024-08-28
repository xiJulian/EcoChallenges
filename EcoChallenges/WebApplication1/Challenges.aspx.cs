using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.ServiceReference1;

namespace WebApplication
{
  public partial class Challenges : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Service1Client service = new Service1Client();

      CardRepeater.DataSource = service.GetAllChallenges();
      CardRepeater.DataBind();
    }
  }
}