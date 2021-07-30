using F4CIO.Restro.Data;
using F4CIO.Restro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F4CIO.Restro.BusinessLogic.Test
{
    public class HandlerForRoomsMock : F4CIO.Restro.Data.IHandlerForRooms
    {
        public ChatRoom GetRoomById(int id)
        {
            var rooms = F4CIO.Restro.Common.DummyDataGenerator.GenerateDummyRooms();
            var r = rooms.Items.SingleOrDefault(room => room.Id == id);
            return r;
        }
    }
}
