using FluentAPIExample.Abstact;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FluentAPIExample
{
    public class FluentSqlConnection :
        IServerSelectionStage,
        IDatabaseSelectionStage,
        IUserSelectionStage,
        IPasswordSelectionStage,
        IConnectionInitilizerStage
    {
        private string _server;
        private string _database;
        private string _user;
        private string _password;


        private FluentSqlConnection() { }

        public static IServerSelectionStage CreateConnection(Action<ConnectionConfiguration> config)
        {
            var configuration = new ConnectionConfiguration();
            config?.Invoke(configuration);
            return new FluentSqlConnection();
        }
        public static IServerSelectionStage CreateConnection()
        {
            return new FluentSqlConnection();
        }
        public IDatabaseSelectionStage ForServer(string server)
        {
            _server = server;
            return this;
        }

        public IUserSelectionStage ForDatabase(string database)
        {
            _database = database;
            return this;
        }

        public IPasswordSelectionStage AsUser(string userName)
        {
            _user = userName;
            return this;
        }

        public IConnectionInitilizerStage WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public IDbConnection Connect()
        {
            var connection = new SqlConnection($"Server={_server};Database={_database};User Id={_user};Password={_password}");
            connection.Open();
            return connection;
        }

    }
    public class ConnectionConfiguration
    {
        public string ConnectionName { get; set; }
    }
}
