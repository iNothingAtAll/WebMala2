using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Datos
{
    public class UsersData
    {
        Persistencia persistencia = new Persistencia();

        public DataSet showUsers()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet data = new DataSet();

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spSelectUsers";
            selectedCmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = selectedCmd;
            adapter.Fill(data);
            persistencia.closeConnection();

            return data;
        }

        public bool saveUsers(string _mail, string _password, string _salt, string _state)
        {
            bool executed = false;
            int row;

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spInsertUsers"; //nombre del procedimiento almacenado
            selectedCmd.CommandType = CommandType.StoredProcedure;
            selectedCmd.Parameters.Add("p_mail", MySqlDbType.VarString).Value = _mail;
            selectedCmd.Parameters.Add("p_password", MySqlDbType.VarString).Value = _password;
            selectedCmd.Parameters.Add("p_salt", MySqlDbType.VarString).Value = _salt;
            selectedCmd.Parameters.Add("p_state", MySqlDbType.VarString).Value = _state;

            try
            {
                row = selectedCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            persistencia.closeConnection();
            return executed;
        }

        public bool updateUsers(int _id, string _mail, string _password, string _salt, string _state)
        {
            bool executed = false;
            int row;

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spUpdateUsers"; //nombre del procedimiento almacenado
            selectedCmd.CommandType = CommandType.StoredProcedure;
            selectedCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            selectedCmd.Parameters.Add("p_mail", MySqlDbType.VarString).Value = _mail;
            selectedCmd.Parameters.Add("p_password", MySqlDbType.VarString).Value = _password;
            selectedCmd.Parameters.Add("p_salt", MySqlDbType.VarString).Value = _salt;
            selectedCmd.Parameters.Add("p_state", MySqlDbType.VarString).Value = _state;

            try
            {
                row = selectedCmd.ExecuteNonQuery();
                if (row == 1)
                {
                    executed = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
            }
            persistencia.closeConnection();
            return executed;
        }
    }
}