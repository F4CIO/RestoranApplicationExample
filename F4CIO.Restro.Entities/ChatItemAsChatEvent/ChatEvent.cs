using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.Entities
{
    public class ChatEvent:ChatItem
    {
        public override DateTime Moment { get; set; }
        public ChatUser User;
        public override List<string> GetLines()
        {
            return new List<string>() { this.ToString() };
        }
    }
}
