using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class UserChallenge
  {
    public int challengeId { get; set; }
    public string userEmail { get; set; }
    public string startedAt { get; set; }
    public string completedAt { get; set; }
    public bool isCompleted { get; set; }
    public string comment { get; set; }
  }
}
