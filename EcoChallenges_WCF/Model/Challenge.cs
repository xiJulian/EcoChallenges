using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Challenge
  {
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string createdAt { get; set; }
    public int points { get; set; }
  }
}
