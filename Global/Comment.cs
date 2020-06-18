using System;
using System.Collections.Generic;
using System.Text;

namespace Global
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
    }
}
