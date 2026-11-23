using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XmlToList
{
    public class ConnectionManager
    {
        private static readonly Lazy<ConnectionManager> instance = new Lazy<ConnectionManager>(() => new ConnectionManager(), LazyThreadSafetyMode.ExecutionAndPublication);
        private Dictionary<string, string> _connDic = null;

        private ConnectionManager()
        {
            _connDic = new Dictionary<string, string>();
            GetConnectionString();
        }

        static ConnectionManager() { }

        public static ConnectionManager Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private void GetConnectionString()
        {
            string Instance = string.Empty;
            string ConnectionString = string.Empty;
            ConnectionStringSettingsCollection ConnectionCollection = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings item in ConnectionCollection)
            {
                Instance = item.Name;
                ConnectionString = item.ConnectionString;
                if (Instance != ApplicationConstant.LocalSqlServer)
                {
                    if (!_connDic.ContainsKey(Instance))
                    {
                        _connDic.Add(Instance, ConnectionString);
                    }
                }
            }
        }

        public string GetConnection(string Instance)
        {
            string conn = string.Empty;
            if (_connDic.ContainsKey(Instance))
            {
                conn = _connDic[Instance];
                if (string.IsNullOrEmpty(conn))
                {
                    return string.Empty;
                }
                else
                {
                    return conn;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
