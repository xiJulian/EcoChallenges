using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Message
  {
    public int id { get; set; }
    public string email { get; set; }
    public string subject { get; set; }
    public string content { get; set; }
    public string sentAt { get; set; }
    public bool isRead { get; set; }
  }
}
