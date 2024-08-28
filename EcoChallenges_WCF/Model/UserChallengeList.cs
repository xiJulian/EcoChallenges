using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class UserChallengeList : List<UserChallenge>
  {
    public UserChallengeList() { }
    public UserChallengeList(IEnumerable<UserChallenge> list) : base(list) { }
  }
}
