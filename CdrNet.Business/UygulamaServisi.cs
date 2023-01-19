using CdrNet.Business.KasaAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdrNet.Business
{
    public class UygulamaServisi
    {
        private KasaServisi kasaServisi=new KasaServisi();

        public double KasaBakiyesi() => kasaServisi.Bakiye();

        public IReadOnlyCollection<Kasa> KasaListesi() => kasaServisi.KasaListesi();
    }
}
