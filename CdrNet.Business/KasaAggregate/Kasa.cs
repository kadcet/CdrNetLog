using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdrNet.Business.KasaAggregate
{
    public class Kasa
    {
        public IslemTipi _islemTipi;
        public DateTime _tarih;
        public string _aciklama;
        public double _tutar;

        public Kasa(IslemTipi tip,DateTime tarih,string aciklama,double tutar)
        {
            _islemTipi = tip;
            _tarih = tarih;
            _aciklama = aciklama;
            _tutar = tutar;

        }
    }
}
