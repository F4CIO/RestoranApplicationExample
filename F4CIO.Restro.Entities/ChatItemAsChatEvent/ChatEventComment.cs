using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F4CIO.Restro.Entities
{
    public class ChatEventComment: ChatEvent
    {
        public string CommentBody { get; set; }

        public override string ToString()
        {
            return $"{this.User.Username} comments: {this.CommentBody}";
        }
    }
}
