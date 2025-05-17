using System.Data;
using Data;

namespace Logic
{
    public class ProvidersLogic
    {
        ProvidersData objPrv = new ProvidersData();

        public DataSet showProvidersDDL()
        {
            return objPrv.showProvidersDDL();
        }

        public DataSet showProviders()
        {
            return objPrv.showProviders();
        }

        public bool saveProvider(string _nit, string _name)
        {
            return objPrv.saveProvider(_nit, _name);
        }

        public bool updateProvider(int _id, string _nit, string _name)
        {
            return objPrv.updateProvider(_id, _nit, _name);
        }
    }
}