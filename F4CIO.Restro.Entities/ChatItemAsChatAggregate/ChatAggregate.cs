using System;
using System.Collections.Generic;
using System.Text;

namespace F4CIO.Restro.Entities
{
    public class ChatAggregate:ChatItem
    {
        public override DateTime Moment { get; set; }
        public List<ChatAggregateForChatType> ChatAggregatesForChatTypes { get; set; }
        public override List<string> GetLines()
        {
            var r = new List<string>();
            foreach(var chatAggregatesForChatType in this.ChatAggregatesForChatTypes)
            {
                r.Add(chatAggregatesForChatType.ToString());
            }
            return r;
        }
    }

}
