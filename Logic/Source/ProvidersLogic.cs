using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logic.Source
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