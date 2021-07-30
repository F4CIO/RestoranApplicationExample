using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.BusinessLogic
{
    public class HandlersFactory
    {
        private static IHandlerBase _HandlerBase = null;
        public static IHandlerBase HandlerBase
        {
            get
            {
                if (_HandlerBase == null)
                {
                    _HandlerBase = new HandlerBase();
                }
                return _HandlerBase;
            }
            set
            {
                _HandlerBase = value;//use this for unit testing
            }
        }

        private static IHandlerForRooms _HandlerForRoom = null;
        public static IHandlerForRooms HandlerForRoom
        {
            get
            {
                if (_HandlerForRoom == null)
                {
                    _HandlerForRoom = new HandlerForRooms();
                }
                return _HandlerForRoom;
            }
            set
            {
                _HandlerForRoom = value;//use this for unit testing
            }
        }


    }
}
