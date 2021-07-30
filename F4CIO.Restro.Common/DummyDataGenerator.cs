using F4CIO.Restro.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace F4CIO.Restro.Common
{
    public static class DummyDataGenerator
    {
        public static ChatRooms GenerateDummyRooms()
        {
            ChatRooms r = new ChatRooms();
            r.Items = new List<ChatRoom>();

            var userBob = new ChatUser { Username = "Bob" };
            var userKate = new ChatUser { Username = "Kate" };
            var userMark = new ChatUser { Username = "Mark" };
            var userDave = new ChatUser { Username = "Dave" };
            var userAnna = new ChatUser { Username = "Anna" };

            var r1 = new ChatRoom
            {
                Id = 1,
                Name = "Dummy room 1",
                Items = new List<ChatItem>() {
                    new ChatEventEntry { Moment = new DateTime(2021,05,26,17,0,0), User = userBob},
                    new ChatEventEntry { Moment = new DateTime(2021,05,26,17,5,0), User = userKate},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,17,15,0), User = userBob, CommentBody= "Hey, Kate - high five?"},
                    new ChatEventHighFive { Moment = new DateTime(2021,05,26,17,17,0), User = userKate, Targets = new List<ChatUser>(){userBob } },
                    new ChatEventLeave { Moment = new DateTime(2021,05,26,17,18,0), User = userBob},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,17,20,0), User = userKate, CommentBody= "Oh, typical"},
                    new ChatEventLeave { Moment = new DateTime(2021,05,26,17,21,0), User = userKate},

                    new ChatEventEntry { Moment = new DateTime(2021,05,26,18,0,0), User = userMark},
                    new ChatEventEntry { Moment = new DateTime(2021,05,26,18,10,0), User = userDave},
                    new ChatEventEntry { Moment = new DateTime(2021,05,26,18,15,0), User = userAnna},
                    new ChatEventHighFive { Moment = new DateTime(2021,05,26,18,17,0), User = userMark, Targets = new List<ChatUser>(){userBob, userDave } },
                    new ChatEventHighFive { Moment = new DateTime(2021,05,26,18,18,0), User = userMark, Targets = new List<ChatUser>(){userAnna } },
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,21,0), User = userMark, CommentBody= "Hello example 1"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,22,0), User = userDave, CommentBody= "Hello example 2"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,23,0), User = userAnna, CommentBody= "Hello example 3"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,24,0), User = userMark, CommentBody= "Hello example 4"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,25,0), User = userMark, CommentBody= "Hello example 5"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,26,0), User = userMark, CommentBody= "Hello example 6"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,27,0), User = userMark, CommentBody= "Hello example 7"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,28,0), User = userMark, CommentBody= "Hello example 8"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,29,0), User = userMark, CommentBody= "Hello example 9"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,30,0), User = userMark, CommentBody= "Hello example 10"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,31,0), User = userMark, CommentBody= "Hello example 11"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,32,0), User = userMark, CommentBody= "Hello example 12"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,33,0), User = userMark, CommentBody= "Hello example 13"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,34,0), User = userMark, CommentBody= "Hello example 14"},
                    new ChatEventComment { Moment = new DateTime(2021,05,26,18,35,0), User = userMark, CommentBody= "Hello example 15"},
                }
            };
            r.Items.Add(r1);



            return r;
        }
    }
}
