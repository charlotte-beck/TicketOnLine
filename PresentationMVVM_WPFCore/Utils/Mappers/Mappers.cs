using Repositories.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationMVVM_WPFCore.Utils.Mappers
{
    public static class Mappers
    {
        public static Comment ToWpf(this Comment_User_Event c)
        {
            return new Comment
            {
                CommentDate = c.CommentDate,
                CommentContent = c.CommentContent
            };
        }
    }
}
