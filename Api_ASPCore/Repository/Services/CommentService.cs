using Global;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ASPCore.Repository.Services
{
    public class CommentService : ICommentRepository<Comment, Comment_User_Event>
    {
        private static ICommentRepository<Comment, Comment_User_Event> _instance;
        public static ICommentRepository<Comment, Comment_User_Event> Instance
        {
            get
            {
                return _instance ?? (_instance = new CommentService());
            }
        }

        private SqlConnection _connection;
        public CommentService()
        {
            _connection = new SqlConnection(@"Data Source=FORMA-VDI1106\TFTIC;Initial Catalog=DatabaseTicketOnLine;Integrated Security=True");
            _connection.Open();
        }

        public List<Comment_User_Event> GetAllCommentByEvent(int eventId)
        {
            List<Comment_User_Event> comments = new List<Comment_User_Event>();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetAllComment_Event";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EventId", eventId);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    comments.Add(new Comment_User_Event
                    {
                        CommentId = (int)dr["CommentId"],
                        UserId = (int)dr["UserId"],
                        EventId = (int)dr["EventId"],
                        CommentDate = (DateTime)dr["CommentDate"],
                        CommentContent = (string)dr["CommentContent"],
                        User = (string)dr["User"],
                        Event = (string)dr["Event"]
                    });
                }
            }
            return comments;
        }

        public Comment_User_Event GetOneComment(int commentId)
        {
            Comment_User_Event reservation = new Comment_User_Event();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetComment";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CommentId", commentId);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    reservation.CommentId = (int)dr["CommentId"];
                    reservation.UserId = (int)dr["UserId"];
                    reservation.EventId = (int)dr["EventId"];
                    reservation.CommentDate = (DateTime)dr["CommentDate"];
                    reservation.CommentContent = (string)dr["CommentContent"];
                    reservation.User = (string)dr["User"];
                    reservation.Event = (string)dr["Event"];
                }
            }
            return reservation;
        }

        public List<Comment_User_Event> GetAllCommentByUser(int userId)
        {
            List<Comment_User_Event> comments = new List<Comment_User_Event>();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_GetAllComment_User";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", userId);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    comments.Add(new Comment_User_Event
                    {
                        CommentId = (int)dr["CommentId"],
                        UserId = (int)dr["UserId"],
                        EventId = (int)dr["EventId"],
                        CommentDate = (DateTime)dr["CommentDate"],
                        CommentContent = (string)dr["CommentContent"],
                        User = (string)dr["User"],
                        Event = (string)dr["Event"]
                    });
                }
            }
            return comments;
        }

        public Comment CreateComment(Comment entity)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_CreateComment";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("UserId", entity.UserId);
            command.Parameters.AddWithValue("EventId", entity.EventId);
            command.Parameters.AddWithValue("CommentDate", entity.CommentDate);
            command.Parameters.AddWithValue("CommentContent", entity.CommentContent);


            command.ExecuteNonQuery();
            return entity;
        }

        //public bool UpdateComment(int commentId, Comment entity)
        //{
        //    SqlCommand command = _connection.CreateCommand();
        //    command.CommandText = "SP_UpdateComment";
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.Parameters.AddWithValue("@CommentId", commentId);
        //    command.Parameters.AddWithValue("@UserId", entity.UserId);
        //    command.Parameters.AddWithValue("@EventId", entity.EventId);
        //    command.Parameters.AddWithValue("@CommentDate", entity.CommentDate);
        //    command.Parameters.AddWithValue("@CommentContent", entity.CommentContent);
        //    return command.ExecuteNonQuery() == 1;
        //}

        public void DeleteComment(int commentId)
        {
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "dbo.SP_DeleteComment";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("CommentId", commentId);
            command.ExecuteNonQuery();
        }
    }
}
