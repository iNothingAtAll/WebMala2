using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class CategoryData
    {
        Persistencia persistencia = new Persistencia();

        public DataSet showCategories() { 
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet data = new DataSet();

            MySqlCommand selectCmd = new MySqlCommand();
            selectCmd.Connection = persistencia.openConnection();
            selectCmd.CommandText = "spSelectCategory";
            selectCmd.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = selectCmd;
            adapter.Fill(data);

            persistencia.closeConnection();
            return data;
        }

        public bool saveCategory(string _description)
        {
            bool executed = false;
            int row;

            MySqlCommand selectCmd = new MySqlCommand();
            selectCmd.Connection = persistencia.openConnection();
            selectCmd.CommandText = "spInsertCategory"; //nombre del procedimiento almacenado
            selectCmd.CommandType = CommandType.StoredProcedure;
            selectCmd.Parameters.Add("p_description", MySqlDbType.VarString).Value = _description;

            try
            {
                row = selectCmd.ExecuteNonQuery();
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

        public bool updateCategory(int _idCategory, string _description)
        {
            bool executed = false;
            int row;

            MySqlCommand selectCmd = new MySqlCommand();
            selectCmd.Connection = persistencia.openConnection();
            selectCmd.CommandText = "spUpdateCategory"; //nombre del procedimiento almacenado
            selectCmd.CommandType = CommandType.StoredProcedure;
            selectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idCategory;
            selectCmd.Parameters.Add("p_description", MySqlDbType.VarString).Value = _description;

            try
            {
                row = selectCmd.ExecuteNonQuery();
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

        public bool deleteCategory(int _idCategory)
        {
            bool executed = false;
            int row;

            MySqlCommand selectCmd = new MySqlCommand();
            selectCmd.Connection = persistencia.openConnection();
            selectCmd.CommandText = "spDeleteCategory"; //nombre del procedimiento almacenado
            selectCmd.CommandType = CommandType.StoredProcedure;
            selectCmd.Parameters.Add("p_id", MySqlDbType.Int32).Value = _idCategory;

            try
            {
                row = selectCmd.ExecuteNonQuery();
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