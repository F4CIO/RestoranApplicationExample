using F4CIO.Restro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F4CIO.Restro.Data
{
    public interface IHandlerForRooms
    {
        ChatRoom GetRoomById(int id);
    }

    public class HandlerForRooms:HandlerBase, IHandlerForRooms
    {
        public ChatRoom GetRoomById(int id)
        {
            //of course we would pull data from DB via entity framework, 
            //POCO entities could be automatically generated via into ...Entities project
            //can show all that from last project
            var rooms = F4CIO.Restro.Common.DummyDataGenerator.GenerateDummyRooms();
            var r = rooms.Items.SingleOrDefault(room => room.Id == id);
            return r;
        }
    }
}
