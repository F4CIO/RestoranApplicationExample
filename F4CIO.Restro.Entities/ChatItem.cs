using System;
using System.Collections.Generic;
using System.Text;

namespace F4CIO.Restro.Entities
{
    public abstract class ChatItem
    {
        public abstract DateTime Moment { get; set; }
        public abstract List<string> GetLines();
    }
}
