using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaKB.Classlar.JsonClass
{
    public class Konum
    {
        // İsim ve konum bilgisini temsil eden sınıf
        public class isimkonum
        {
            public string name { get; set; }
            public string path { get; set; }
        }

        // Bir grup konumu temsil eden sınıf
        public class konumlar
        {
            public List<isimkonum> Konumlar { get; set; }
        }

        public string KonumBilgisi(int i)
        {
            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar konuJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);

            // VoTTClass sınıfını seçilen yol ile başlat
            return konuJson.Konumlar[i].path;
        }

        public List<isimkonum> KonumListesi()
        {
            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar konuJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);
            konuJson.Konumlar.RemoveAll(item => !File.Exists(item.path));

            // Güncellenen yolları JSON dosyasına kaydet
            jsonContent = JsonConvert.SerializeObject(konuJson, Formatting.Indented);
            File.WriteAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json", jsonContent);

            // Geçerli yolların listesini döndür
            List<isimkonum> konumlar = konuJson.Konumlar;
            return konumlar;
        }

        public int KonumSayisi()
        {
            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar ExportJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);
            return ExportJson.Konumlar.Count;
        }

        public void KonumOlusturma(string isim, string konum)
        {

            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar ExportJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);
            ExportJson.Konumlar.Add(new isimkonum() { name = isim, path = konum + isim + ".vott" });

            // Güncellenen veriyi kaydet
            jsonContent = JsonConvert.SerializeObject(ExportJson, Formatting.Indented);
            File.WriteAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json", jsonContent);

            // Gerekli dizinleri oluştur
            Directory.CreateDirectory(konum + "vott-json-export\\");
        }

        public void KonumEkleme(string isim, string konum)
        {
            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar ExportJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);
            ExportJson.Konumlar.Add(new isimkonum() { name = isim, path = konum });

            // Güncellenen veriyi kaydet
            jsonContent = JsonConvert.SerializeObject(ExportJson, Formatting.Indented);
            File.WriteAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json", jsonContent);
        }

        public void KonumSilme(int i)
        {
            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar ExportJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);
            ExportJson.Konumlar.RemoveAt(i);

            // Güncellenen veriyi kaydet
            jsonContent = JsonConvert.SerializeObject(ExportJson, Formatting.Indented);
            File.WriteAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json", jsonContent);
        }

        public void KonumBilgsiDegistir(int i,string konum)
        {
            string jsonContent = File.ReadAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json");
            konumlar ExportJson = JsonConvert.DeserializeObject<konumlar>(jsonContent);
            ExportJson.Konumlar[i] = new isimkonum() { name = ExportJson.Konumlar[i].name, path = konum };

            // Güncellenen veriyi kaydet
            jsonContent = JsonConvert.SerializeObject(ExportJson, Formatting.Indented);
            File.WriteAllText("C:\\Users\\asus\\source\\repos\\MangaKB\\MangaKB\\Json\\Konum.json", jsonContent);
        }
    }
}
