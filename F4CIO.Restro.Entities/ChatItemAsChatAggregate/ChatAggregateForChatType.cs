using System;
using System.Collections.Generic;
using System.Text;

namespace F4CIO.Restro.Entities
{
    public class ChatAggregateForChatType
    {
        public ChatEventType EventType { get; set; }
        public List<ChatItem> Source { get; set; }
        public override string ToString()
        {
            string r;

            switch (this.EventType)
            {
                case ChatEventType.Entry: r = $"{this.Source.Count} people entered"; break;
                case ChatEventType.Leave: r = $"{this.Source.Count} person left"; break;
                case ChatEventType.Comment: r = $"{this.Source.Count} comments"; break;
                case ChatEventType.HighFive:
                    List<ChatUser> p = new List<ChatUser>();
                    List<ChatUser> t = new List<ChatUser>();
                    foreach(var e in this.Source)
                    {
                        var eAsHighFive = e as ChatEventHighFive;
                        if (!p.Contains(eAsHighFive.User))
                        {
                            p.Add(eAsHighFive.User);
                        }
                        t.AddRange(eAsHighFive.Targets);
                    }
                    r = $"{p.Count} person high-fived {t.Count} other people"; 
                    break;
                default: throw new NotImplementedException();
            }

            return r;
        }
    }
}
