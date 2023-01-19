using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdrNet.Business.LogAggregate
{
    public class Log
    {
        public LogTipi _logtipi;

        public DateTime _logTarihi;

        public string _logMesaji;

        public Log(LogTipi tip,DateTime tarih,string logMesaji)
        {
            _logtipi = tip;
            _logTarihi = tarih;
            _logMesaji = logMesaji;
        }

        
    }
}
