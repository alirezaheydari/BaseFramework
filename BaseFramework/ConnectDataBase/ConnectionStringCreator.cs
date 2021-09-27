using System;
using System.Collections.Generic;
using System.Text;

namespace BaseFramework.ConnectDataBase
{
    public static class ConnectionStringCreator
    {

        /// <summary>
        /// GetConnectionString
        /// </summary>
        private static string ConnectionStringForConnected { get { return _ConnectionStringForConnected; } }

        #region :Fields
        private static string DataSource;
        private static string Database;
        private static string Username;
        private static string Password;
        private static string _ConnectionStringForConnected;
        private static bool _IsWindowsAuthentication = true;
        private static string _StringForWindowsAuthentication = ";integrated security=sspi;";
        #endregion

        #region :Costructor
        public static string GetConnectionString(string datasource, string database, string username, string password)
        {
            _IsWindowsAuthentication = false;
            SetDatasourceAndDatabase(datasource, database);
            Username = username;
            Password = password;
            _ConnectionStringForConnected = SetAndGetStringForConnection();
            return ConnectionStringForConnected;
        }
        public static string GetConnectionString(string datasource, string database)
        {
            SetDatasourceAndDatabase(datasource, database);
            _ConnectionStringForConnected = SetAndGetStringForConnection();
            return ConnectionStringForConnected;
        }
        #endregion

        #region :Methuds
        private static void SetDatasourceAndDatabase(string datasource, string database)
        {
            DataSource = datasource;
            Database = database;
        }
        private static string SetAndGetStringForConnection()
        {
            if (!Username.IsNotNullOrEmpty() && !Password.IsNotNullOrEmpty())
                return string.Format("data source={0};database={1};uid={1};pwd={2}", DataSource, Database, Username, Password);
            else if (_IsWindowsAuthentication)
                return string.Format("data source={0};database={1}{2}", DataSource, Database, _StringForWindowsAuthentication);
            return "";
        }
        #endregion
    }
}
