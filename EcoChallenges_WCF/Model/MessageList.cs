using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class MessageList : List<Message>
  {
    public MessageList() { }
    public MessageList(IEnumerable<Message> list) : base(list) { }
  }
}
