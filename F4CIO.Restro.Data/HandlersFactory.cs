using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.Data
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

        private static IHandlerForRooms _HandlerForRooms = null;
        public static IHandlerForRooms HandlerForRooms
        {
            get
            {
                if (_HandlerForRooms == null)
                {
                    _HandlerForRooms = new HandlerForRooms();
                }
                return _HandlerForRooms;
            }
            set
            {
                _HandlerForRooms = value;//use this for unit testing
            }
        }

        private static HandlerForChatEvents _HandlerForChatEvents = null;
        public static HandlerForChatEvents HandlerForChatEvents
        {
            get
            {
                if (_HandlerForChatEvents == null)
                {
                    _HandlerForChatEvents = new HandlerForChatEvents();
                }
                return _HandlerForChatEvents;
            }
            set
            {
                _HandlerForChatEvents = value;//use this for unit testing
            }
        }
    }
}
