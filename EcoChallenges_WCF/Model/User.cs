using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class User
  {
    public int id { get; set; }
    public string email { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string password { get; set; }
    public int points { get; set; }
    public City city { get; set; }
  }
}
