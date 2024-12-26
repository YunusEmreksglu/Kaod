using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static MangaKB.Classlar.JsonClass.Export;
using static MangaKB.Classlar.JsonClass.AssetJson;
using System.Windows.Forms.Design;
using MangaKB.Classlar.JsonClass;
using static TorchSharp.torch.utils;

namespace MangaKB.Classlar
{
    public class JsonMain
    {
        public class Bilgi
        {
            public string isim { get; set; }
            public string konum { get; set; }
            public string Tagler { get; set; }
            public string AssetSayisi { get; set; }
        }

        static string Konum;
        static string Name;

        // JSON ve veri işlemleri için kullanılan sınıf değişkenleri
        static AssetJson AssetJsonClass;
        static Export ExportClass;
        static VoTT VoTTClass;
        static Konum KonumClass = new Konum();

        // Yapıcı metod
        public JsonMain()
        {
        }

        static void CopyDirectory(string sourceDir, string targetDir)
        {
            // Hedef dizini oluştur (varsa bir şey yapmaz)
            Directory.CreateDirectory(targetDir);

            // Kaynak dizindeki tüm dosyaları al ve kopyala
            foreach (string filePath in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(filePath);
                string targetFilePath = Path.Combine(targetDir, fileName);
                File.Copy(filePath, targetFilePath, true); // true: üzerine yazmayı sağlar
                Console.WriteLine($"Dosya kopyalandı: {filePath} -> {targetFilePath}");
            }

            // Alt dizinleri al ve özyinelemeli olarak kopyala
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string targetSubDir = Path.Combine(targetDir, subDirName);
                CopyDirectory(subDir, targetSubDir);
            }
        }

        public void Bilgidegistir(int i, string konum)
        {
            CopyDirectory(Konum, konum);

            KonumClass.KonumBilgsiDegistir(i, konum);
            AssetJsonClass.AssetBilgisiDegistir(konum);
            VoTTClass.KonumBilgisiDegistir(konum);
            KonumEkleme(Name, konum);

            KonumSilme(i);




        }

        public Bilgi ToplamBilgi(int i)
        {
            Bilgi bilgi = new Bilgi();

            KonumBilgisi(i);

            bilgi.isim = Name;
            bilgi.konum = Konum;
            bilgi.Tagler = VoTTClass.Tags().Count.ToString();
            bilgi.AssetSayisi = Resimler().Count.ToString();

            return bilgi;
        }

        public void KonumBilgisi(int i)
        {
            VoTTClass = new VoTT(KonumClass.KonumBilgisi(i));
            Konum = VoTTClass.Konum();
            Name = VoTTClass.Name();

            // AssetJsonClass sınıfını başlat
            AssetJsonClass = new AssetJson(Konum);
            ExportClass = new Export(Konum, Name);
        }

        public void KonumOlusturma(string isim, string konum)
        {
            KonumClass.KonumOlusturma(isim, konum);
            VoTTClass = new VoTT(KonumClass.KonumBilgisi(KonumClass.KonumSayisi() - 1));
            VoTTClass.olustur(isim, konum);
            KonumBilgisi(KonumClass.KonumSayisi() - 1);
            ExportClass.export();


        }

        // JSON dosyasına yeni bir giriş ekleyen metod
        public void KonumEkleme(string isim, string konum)
        {
            KonumClass.KonumEkleme(isim, konum);
        }

        public void KonumSilme(int i)
        {
            KonumClass.KonumSilme(i);
        }

        // Geçerli yolları güncelleyen ve döndüren metod
        public List<Konum.isimkonum> KonumListesi()
        {
            return KonumClass.KonumListesi();
        }

        // Veriyi kaydeden metod
        public void Save(List<Kutu> Kutular, int ImageWidth, int ImageHeight, FileInfo ImagePaht, Image Image)
        {
            // Veriyi AssetJsonClass ile kaydet
            AssetJson.AssetData AssetData = AssetJsonClass.Save(Kutular, ImageWidth, ImageHeight, ImagePaht, Image);
            // Veri varlıklarını dışa aktar
            VoTTClass.Save(AssetData.asset);

            // Kullanıcıya başarı mesajı göster
            MessageBox.Show("やったー！");
        }

        // Etiketleri getiren metod
        public List<List<string>> Tags()
        {
            try
            {
                return VoTTClass.Tags();
            }
            catch
            {
                return null;
            }
        }

        public void TagEkle(string Name , string Renk)
        {
            VoTTClass.TagEkle(Name, Renk);
        }

        public void TagSilme(int i)
        {
            VoTTClass.TagSilme(i);
        }

        // Görüntü verilerini getiren metod
        public List<AssetJson.AssetData> Resimler()
        {
            return AssetJsonClass.ResimLer();
        }

        // Veriyi dışa aktaran metod
        public void Export()
        {
            ExportClass.export();

        }

        // Varlık isimlerini getiren metod
        public List<string> AssetsName()
        {
            if (File.Exists(Konum + "vott-json-export\\" + Name + "-export.json"))  return ExportClass.Denetim();
            else return null;
        }

        // Dosya oluşturma tarihini getiren metod
        public DateTime DostaTarihi()
        {
            if (File.Exists(Konum + "vott-json-export\\" + Name + "-export.json")) return ExportClass.DosyaTarihi();
            else return new DateTime(0);
        }

    }
}
