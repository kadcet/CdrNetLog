using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdrNet.Data.Txt
{
    public class DosyaBulunamadiException:Exception
    {
        public DosyaBulunamadiException(string dosyaYolu)
            : base($"{dosyaYolu} yolundaki dosya okunamadı")
        {
            
        }
    }
}
