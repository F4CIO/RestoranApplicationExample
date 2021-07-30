using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.Entities
{
    public class ChatEventHighFive : ChatEvent
    {
        public List<ChatUser> Targets { get; set; }

        public override string ToString()
        {
            string tt = string.Empty;
            this.Targets.ForEach(t => tt += t.Username + ",");
            tt = tt.Trim(',');

            return $"{this.User.Username} high-fives {tt}";
        }
    }
}
