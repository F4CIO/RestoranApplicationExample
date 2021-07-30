using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.Entities
{
    public class ChatEventLeave : ChatEvent
    {
        public override string ToString()
        {
            return $"{this.User.Username} leaves";
        }
    }
}
