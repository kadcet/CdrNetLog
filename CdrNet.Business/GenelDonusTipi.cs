using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdrNet.Business
{
    public class GenelDonusTipi
    {
        public bool hataVarMi;
        public string hataMesaji;
        public object data;

        public GenelDonusTipi(bool _hataVarMi,string _hataMesaji,object _data)
        {
            hataMesaji = _hataMesaji;
            hataMesaji = _hataMesaji;
            data = _data;
        }

        public GenelDonusTipi(bool _hataVarMi, string _hataMesaji):this(_hataVarMi,_hataMesaji,null)
        {
           
        }

        public GenelDonusTipi(bool _hataVarMi, object _data) : this(_hataVarMi,null,_data)
        {

        }

        public GenelDonusTipi(bool _hataVarMi) : this(_hataVarMi, null, null)
        {

        }
    }
}
