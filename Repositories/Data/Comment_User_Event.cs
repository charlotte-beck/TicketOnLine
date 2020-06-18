using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Data
{
    public class Comment_User_Event
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
        public string User { get; set; }
        public string Event { get; set; }
    }
}
