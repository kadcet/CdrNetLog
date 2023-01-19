using CdrNet.Business.LogAggregate;
using CdrNet.Data.Txt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CdrNet.Business.KasaAggregate
{
    internal class KasaServisi
    {
        private static List<Kasa> liste = new List<Kasa>();

        static KasaServisi()
        {
            KasaYukle();
        }

        private static void KasaYukle()
        {
            string data = "[]";
            try
            {
                data = DosyaIslemleri.Oku(Sabitler.KASA_DOSYA_YOLU);
                liste = JsonSerializer.Deserialize<List<Kasa>>(data, new JsonSerializerOptions { IncludeFields = true });

                StringBuilder sb = new StringBuilder();
                sb.Append("*******************");
                sb.Append($"Log Seviyesi :{LogTipi.Information.ToString()} \r\n");
                sb.Append($"Log Tarihi :{DateTime.Now} \r\n");
                sb.Append("Operasyon Başarılı\r\n");
                sb.Append("*******************");
                LogServisi.Information(sb.ToString());
            }
            catch (DosyaBulunamadiException)
            {
                var json=JsonSerializer.Serialize(data,new JsonSerializerOptions { IncludeFields = true });
                DosyaIslemleri.Kaydet(Sabitler.KASA_DOSYA_YOLU, data);
                
            }catch(Exception ex)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("*******************");
                sb.Append($"Log Seviyesi :{LogTipi.Error.ToString()}\r\n");
                sb.Append($"Log Tarihi : {DateTime.Now}\r\n");
                sb.Append("Hata Oluştu\r\n");
                sb.Append($"Sistem Hata Mesajı :{ex.Message} \r\n");
                sb.Append("*******************");
                LogServisi.Eror(sb.ToString());
                // loglama yapılsın
                // Todo: Sisteme log alt yapısını entegre edin.
            }
        }
        
        public GenelDonusTipi Kaydet(IslemTipi tip,double tutar,string aciklama)
        {
            try
            {
                KasaYukle();
                Kasa k = new Kasa(tip, DateTime.Now, aciklama, tutar);
                liste.Add(k);

                string json = JsonSerializer.Serialize(liste, new JsonSerializerOptions { IncludeFields = true });
                DosyaIslemleri.Kaydet(Sabitler.KASA_DOSYA_YOLU, json);
                StringBuilder sb = new StringBuilder();
                sb.Append("*******************");
                sb.Append($"Log Seviyesi :{LogTipi.Information.ToString()} \r\n");
                sb.Append($"Log Tarihi :{DateTime.Now} \r\n");
                sb.Append("Operasyon Başarılı\r\n");
                sb.Append("*******************");
                LogServisi.Information(sb.ToString());
                return new GenelDonusTipi(false);
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("*******************");
                sb.Append($"Log Seviyesi :{LogTipi.Error.ToString()}\r\n");
                sb.Append($"Log Tarihi : {DateTime.Now}\r\n");
                sb.Append("Hata Oluştu\r\n");
                sb.Append($"Sistem Hata Mesajı :{ex.Message} \r\n");
                sb.Append("*******************");
                LogServisi.Eror(sb.ToString());
                
                //Todo: hatayı log sistemi loglasın
                return new GenelDonusTipi(true, "Kasa İşlemi Kayıt Edilirken Bir Hata Oluştu!\n"+ex.Message);
            }
        }


        // Bizim burada listeyi dosyadan doldurmamız gerekmiyor mu?
        public IReadOnlyCollection<Kasa> KasaListesi() =>  liste.AsReadOnly();

        public IReadOnlyCollection<Kasa> GelirListesi() => liste.Where(k => k._islemTipi == IslemTipi.Gelir).ToList().AsReadOnly();

        public IReadOnlyCollection<Kasa> GiderListesi() => liste.Where(k => k._islemTipi == IslemTipi.Gider).ToList().AsReadOnly();

        public double Bakiye() => GelirListesi().Sum(g => g._tutar) - GiderListesi().Sum(g => g._tutar);
    }
}
