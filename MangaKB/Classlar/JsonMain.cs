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
        public class InfoClass
        {
            public string Name { get; set; }
            public string Location { get; set; }
            public string Tags { get; set; }
            public string AssetCount { get; set; }
        }

        static string Location;
        static string Name;

        static AssetJson AssetJsonClass;
        static Export ExportClass;
        static VoTT VoTTClass;
        static Location LocationClass = new Location();

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

        public void LocationChange(int i, string NewLocation)
        {
            CopyDirectory(Location, NewLocation);

            LocationClass.LocationChange(i, NewLocation);
            AssetJsonClass.AssetBilgisiDegistir(NewLocation);
            VoTTClass.KonumBilgisiDegistir(NewLocation);




        }

        public void LocationNameChange(int i, string NewName)
        {
            LocationClass.LocationNameChange(i, NewName);
            VoTTClass.LocationNameChange(NewName);

        }

        public InfoClass Info(int i)
        {
            InfoClass bilgi = new InfoClass();

            LocationInfo(i);

            bilgi.Name = Name;
            bilgi.Location = Location;
            bilgi.Tags = VoTTClass.Tags().Count.ToString();
            bilgi.AssetCount = Images().Count.ToString();

            return bilgi;
        }

        public void LocationInfo(int i)
        {
            VoTTClass = new VoTT(LocationClass.LocationInfo(i));
            Location = VoTTClass.Location();
            Name = VoTTClass.Name();

            // AssetJsonClass sınıfını başlat
            AssetJsonClass = new AssetJson(Location);
            ExportClass = new Export(Location, Name);
        }

        public void LocationCreate(string isim, string NewLocation)
        {
            LocationClass.LocationCreate(isim, NewLocation);
            VoTTClass = new VoTT(LocationClass.LocationInfo(LocationClass.LocationCount() - 1));
            VoTTClass.olustur(isim, NewLocation);
            LocationInfo(LocationClass.LocationCount() - 1);
            ExportClass.export();


        }

        public void LocationAdd(string isim, string NewLocation)
        {
            LocationClass.LocationAdd(isim, NewLocation);
        }

        public void LocationRemove(int i)
        {
            LocationClass.LocationRemove(i);
        }

        public List<Location.NameandLocation> LocationList()
        {
            return LocationClass.locationsList();
        }

        public void Save(List<Kutu> Kutular, int ImageWidth, int ImageHeight, FileInfo ImagePaht, Image Image)
        {
            AssetJson.AssetData AssetData = AssetJsonClass.Save(Kutular, ImageWidth, ImageHeight, ImagePaht, Image);

            VoTTClass.Save(AssetData.asset);


            MessageBox.Show("Complate Save");
        }

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

        public void TagAdd(string Name , string Renk)
        {
            VoTTClass.TagEkle(Name, Renk);
        }

        public void TagRemove(int i)
        {
            VoTTClass.TagSilme(i);
        }

        public List<AssetJson.AssetData> Images()
        {
            return AssetJsonClass.ResimLer();
        }

        public void Export()
        {
            ExportClass.export();

        }

        public List<string> AssetsName()
        {
            if (File.Exists(Location + "vott-json-export\\" + Name + "-export.json"))  return ExportClass.Denetim();
            else return null;
        }

        public DateTime DostaTarihi()
        {
            if (File.Exists(Location + "vott-json-export\\" + Name + "-export.json")) return ExportClass.DosyaTarihi();
            else return new DateTime(0);
        }

    }
}
