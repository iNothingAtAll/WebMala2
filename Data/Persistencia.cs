using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Persistencia
    {
        MySqlConnection _connection = new MySqlConnection(
            ConfigurationManager.ConnectionStrings["Conn"].ConnectionString
        );

        
        public MySqlConnection openConnection() { 
            try
            {
                _connection.Open();
                return _connection;
            }
            catch(Exception e) {
                e.ToString();
                return null;
            }
        }

        public void closeConnection() {
            _connection.Close();
        }

    }
}