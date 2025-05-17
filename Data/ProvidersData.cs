using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class ProvidersData
    {
        Persistencia persistencia = new Persistencia();

        public DataSet showProvidersDDL()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet data = new DataSet();

            MySqlCommand selectCmd = new MySqlCommand();
            selectCmd.Connection = persistencia.openConnection();
            selectCmd.CommandText = "spSelectProvidersDDL";
            selectCmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = selectCmd;
            adapter.Fill(data);
            persistencia.closeConnection();

            return data;
        }

        public DataSet showProviders()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet data = new DataSet();

            MySqlCommand selectCmd = new MySqlCommand();
            selectCmd.Connection = persistencia.openConnection();
            selectCmd.CommandText = "spSelectProviders";
            selectCmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = selectCmd;
            adapter.Fill(data);
            persistencia.closeConnection();

            return data;
        }

        public bool saveProvider(string _nit, string _name)
        {
            bool executed = false;
            int row;

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spInsertProvider"; //nombre del procedimiento almacenado
            selectedCmd.CommandType = CommandType.StoredProcedure;
            selectedCmd.Parameters.Add("p_nit", MySqlDbType.VarString).Value = _nit;
            selectedCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = _name;

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

        public bool updateProvider(int _id, string _nit, string _name)
        {
            bool executed = false;
            int row;

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spUpdateProvider"; //nombre del procedimiento almacenado
            selectedCmd.CommandType = CommandType.StoredProcedure;
            selectedCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            selectedCmd.Parameters.Add("p_nit", MySqlDbType.VarString).Value = _nit;
            selectedCmd.Parameters.Add("p_name", MySqlDbType.VarString).Value = _name;

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