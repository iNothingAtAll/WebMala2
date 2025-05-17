using Data;
using System.Data;

namespace Logic.Source
{
    public class ProductsLogic
    {
        public class ProductsLog
        {
            ProductsData objPro = new ProductsData();

            public DataSet showProducts()
            {
                return objPro.showProducts();
            }

            public bool saveProducts(string _code, string _description, int _quantity, double _price, int _fHCategory, int _fHProvider)
            {
                return objPro.saveProducts(_code, _description, _quantity, _price, _fHCategory, _fHProvider);
            }

            public bool updateProducts(int _id, string _code, string _description, int _quantity, double _price, int _fHCategory, int _fHProvider)
            {
                return objPro.updateProducts(_id, _code, _description, _quantity, _price, _fHCategory, _fHProvider);
            }
        }
    }
}