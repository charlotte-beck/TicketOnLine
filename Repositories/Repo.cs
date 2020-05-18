//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Repositories
//{
//    public sealed class Service : IService
//    {
//        private IConnection _connection;

//        public Service(IConnection connection)
//        {
//            _connection = connection;
//        }

//        public IEnumerable<string> Get()
//        {
//            Command command = new Command("select Title from ToDo;");
//            return _connection.ExecuteReader(command, dr => (string)dr["Title"]);
//        }
//    }
//}
