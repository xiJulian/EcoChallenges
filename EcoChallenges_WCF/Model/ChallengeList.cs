using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class ChallengeList : List<Challenge>
  {
    public ChallengeList() { }
    public ChallengeList(IEnumerable<Challenge> list) : base(list) { }
  }
}
