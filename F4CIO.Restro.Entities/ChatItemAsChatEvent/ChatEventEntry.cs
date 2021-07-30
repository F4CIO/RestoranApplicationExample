using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.Entities
{
    public class ChatEventEntry : ChatEvent
    {
        public override string ToString()
        {
            return $"{this.User.Username} enters the room";
        }
    }
}
