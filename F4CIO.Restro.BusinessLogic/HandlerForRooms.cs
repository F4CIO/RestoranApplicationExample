using F4CIO.Restro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.BusinessLogic
{
    public interface IHandlerForRooms
    {
        ChatRoom Aggregate(int chatRoomId, AggregationLevel aggregationLevel);
    }

    public class HandlerForRooms:HandlerBase, IHandlerForRooms
    {
        public ChatRoom Aggregate(int chatRoomId, AggregationLevel aggregationLevel)
        {
            ChatRoom r = null;

            //if we were pulling a lot of data from db then EF queries would be used and together with paging (skip and take directives)
            ChatRoom room = F4CIO.Restro.Data.HandlersFactory.HandlerForRooms.GetRoomById(chatRoomId);

            //of course logging and exception handling could be added, can show WELL DEFINED practices I use from other projects...

            if (room != null)
            {
                switch (aggregationLevel)
                {
                    case AggregationLevel.Minute_by_minute:
                        r = room;
                        break;
                    case AggregationLevel.Hourly:
                        r = new ChatRoom();
                        r.Items = new List<ChatItem>();
                        r.Name = room.Name;

                        var eventsByHour = room.Items.GroupBy(
                                e => e.Moment.Hour,
                                e => e,
                                (key, g) => new { eventHour = key, events = g.ToList() }
                            );

                        foreach (var eventsForHour in eventsByHour)
                        {
                            var chatAggregate = new ChatAggregate();
                            chatAggregate.Moment = eventsForHour.events.First().Moment.Date.AddHours(eventsForHour.eventHour);
                            chatAggregate.ChatAggregatesForChatTypes = new List<ChatAggregateForChatType>();

                            var chatEventTypes = Enum.GetValues(typeof(ChatEventType));
                            foreach (ChatEventType chatEventType in chatEventTypes)
                            {
                                var eventsOfSameType = new List<ChatItem>();
                                foreach (var chatEvent in eventsForHour.events)
                                {
                                    if (chatEvent.GetType().FullName.EndsWith(chatEventType.ToString()))
                                    {
                                        eventsOfSameType.Add(chatEvent);
                                    }
                                }

                                if (eventsOfSameType.Count > 0)
                                {
                                    var aggregateForChatType = new ChatAggregateForChatType();
                                    aggregateForChatType.EventType = chatEventType;
                                    aggregateForChatType.Source = eventsOfSameType;
                                    chatAggregate.ChatAggregatesForChatTypes.Add(aggregateForChatType);
                                }
                            }

                            r.Items.Add(chatAggregate);
                        }

                        break;
                    default: throw new NotImplementedException();
                }
            }

            return r;
        }
    }
}
