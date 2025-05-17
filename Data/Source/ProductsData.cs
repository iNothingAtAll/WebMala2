using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Data
{
    public class ProductsData
    {
        Persistencia persistencia = new Persistencia();

        public DataSet showProducts()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataSet data = new DataSet();

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spSelectProducts";
            selectedCmd.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = selectedCmd;
            adapter.Fill(data);
            persistencia.closeConnection();

            return data;
        }

        public bool saveProducts(string _code, string _description, int _quantity, double _price, int _fkcategory, int _fkProvider)
        {
            bool executed = false;
            int row;

            MySqlCommand selectedCmd = new MySqlCommand();
            selectedCmd.Connection = persistencia.openConnection();
            selectedCmd.CommandText = "spInsertProducts"; //nombre del procedimiento almacenado
            selectedCmd.CommandType = CommandType.StoredProcedure;
            selectedCmd.Parameters.Add("p_code", MySqlDbType.VarString).Value = _code;
            selectedCmd.Parameters.Add("p_description", MySqlDbType.VarString).Value = _description;
            selectedCmd.Parameters.Add("p_quantity", MySqlDbType.Int32).Value = _quantity;
            selectedCmd.Parameters.Add("p_price", MySqlDbType.Double).Value = _price;
            selectedCmd.Parameters.Add("p_fkcategory", MySqlDbType.Int32).Value = _fkcategory;
            selectedCmd.Parameters.Add("p_fkprovider", MySqlDbType.Int32).Value = _fkProvider;

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

        public bool updateProducts(int _id, string _code, string _description, int _quantity, double _price, int _fkCategory, int _fkProvider)
        {
            bool executed = false;
            int row;

            MySqlCommand objSelected = new MySqlCommand();
            objSelected.Connection = persistencia.openConnection();
            objSelected.CommandText = "spUpdateProduct"; //nombre del procedimiento almacenado
            objSelected.CommandType = CommandType.StoredProcedure;
            objSelected.Parameters.Add("p_id", MySqlDbType.Int32).Value = _id;
            objSelected.Parameters.Add("p_code", MySqlDbType.VarString).Value = _code;
            objSelected.Parameters.Add("p_description", MySqlDbType.VarString).Value = _description;
            objSelected.Parameters.Add("p_quantity", MySqlDbType.Int32).Value = _quantity;
            objSelected.Parameters.Add("p_price", MySqlDbType.Double).Value = _price;
            objSelected.Parameters.Add("p_fkcategory", MySqlDbType.Int32).Value = _fkCategory;
            objSelected.Parameters.Add("p_fkprovider", MySqlDbType.Int32).Value = _fkProvider;

            try
            {
                row = objSelected.ExecuteNonQuery();
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