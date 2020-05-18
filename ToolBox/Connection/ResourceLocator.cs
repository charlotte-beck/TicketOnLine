//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ToolBox.Connection
//{
//    public sealed class ResourceLocator
//    {
//        #region Singleton
//        private static ResourceLocator _instance;

//        public static ResourceLocator Instance
//        {
//            get
//            {
//                return _instance ?? (_instance = new ResourceLocator());
//            }
//        }

//        private ResourceLocator()
//        {

//        }
//        #endregion
//        private IConnectionInfo _connectionInfo;

//        private IConnectionInfo ConnectionInfo
//        {
//            get
//            {
//                return _connectionInfo ?? (_connectionInfo = new ConnectionInfo(@"Data Source=AW-Briareos\SQL2016DEV;Initial Catalog=GestToDo;Integrated Security=True", SqlClientFactory.Instance));
//            }
//        }

//        private IConnection _connection;

//        private IConnection Connection
//        {
//            get
//            {
//                return _connection = new Connection(ConnectionInfo);
//            }
//        }

//        private IService _service;

//        public IService Service
//        {
//            get
//            {
//                return _service ?? (_service = new Service(Connection));
//            }
//        }
//    }
//}