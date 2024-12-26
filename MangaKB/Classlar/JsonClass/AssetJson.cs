using MangaKB.Classlar;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static MangaKB.Classlar.JsonClass.VoTT;

namespace MangaKB.Classlar.JsonClass
{
    public class AssetJson(string Konum)
    {
        public class AssetData
        {
            public Asset asset { get; set; }
            public List<Region> regions { get; set; }
            public string version { get; set; }
        }

        public class Asset
        {
            public string format { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string path { get; set; }
            public Size size { get; set; }
            public int state { get; set; }
            public int type { get; set; }
        }

        public class Size
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Region
        {
            public string id { get; set; }
            public string type { get; set; }
            public List<string> tags { get; set; }
            public BoundingBox boundingBox { get; set; }
            public List<Point> points { get; set; }
        }

        public class BoundingBox
        {
            public float left { get; set; }
            public float top { get; set; }
            public float width { get; set; }
            public float height { get; set; }
        }

        public class Point
        {
            public float x { get; set; }
            public float y { get; set; }
        }

        private string GenerateRandomId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_"; // Geçerli karakter kümesi
            Random random = new Random();
            char[] id = new char[length];

            for (int i = 0; i < length; i++)
            {
                id[i] = chars[random.Next(chars.Length)]; // Rastgele bir karakter seç
            }

            return new string(id);
        }

        private string Resim(FileInfo ImagePath, Image Image)
        {
            string destinationFilePath = $"{Konum}vott-json-export\\{ImagePath.Name}";

            try
            {
                Image.Save(destinationFilePath);
            }
            catch
            {

            }


            return destinationFilePath;
        }

        public AssetData Save(List<Kutu> Kutular, int ImageWidth, int ImageHeight, FileInfo ImagePath, Image Image)
        {
            List<Region> region = new List<Region>();

            int TagS = 0;

            foreach (var Kutu in Kutular)
            {
                List<Point> points = new List<Point>()
                {
                    new Point()
                    {
                        x = Kutu.Left,
                        y = Kutu.Top
                    },
                    new Point()
                    {
                        x = Kutu.Left + Kutu.Width,
                        y = Kutu.Top
                    },
                    new Point()
                    {
                        x = Kutu.Left + Kutu.Width,
                        y = Kutu.Top + Kutu.Height
                    },
                    new Point()
                    {
                        x = Kutu.Left,
                        y = Kutu.Top + Kutu.Height
                    }
                };

                BoundingBox boundingBox = new BoundingBox() { left = Kutu.Left, top = Kutu.Top, width = Kutu.Width, height = Kutu.Height };

                region.Add(
                    new Region()
                    {
                        id = GenerateRandomId(10),
                        type = "RECTANGLE",
                        tags = new List<string>() { Kutu.Tag },
                        boundingBox = boundingBox,
                        points = points
                    }
                );
            }



            Size size = new Size() { width = ImageWidth, height = ImageHeight };

            Asset asset = new Asset()
            {
                format = ImagePath.Extension.Split('.')[1],
                id = Path.GetFileNameWithoutExtension(ImagePath.Name),
                name = ImagePath.Name,
                path = $"file:{Resim(ImagePath, Image)}",
                size = size,
                state = region.Count,
                type = 1
            };

            AssetData assetData = new AssetData()
            {
                asset = asset,
                regions = region,
                version = "1.0.0"
            };

            string AssetJsonS = JsonConvert.SerializeObject(assetData, Formatting.Indented);

            AssetData AssetJson = JsonConvert.DeserializeObject<AssetData>(AssetJsonS);

            File.WriteAllText($"{Konum}{Path.GetFileNameWithoutExtension(ImagePath.Name)}-asset.json", AssetJsonS);

            return assetData;
        }


        public List<AssetData> ResimLer()
        {
            string folderPath = $"{Konum}";


            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json").OrderBy(dosya => File.GetLastWriteTime(dosya)).ToArray();

            List<AssetData> Resimler = new List<AssetData>();

            foreach (var file in jsonFiles)
            {
                string AssetDataJson = File.ReadAllText(file);
                Resimler.Add(JsonConvert.DeserializeObject<AssetData>(AssetDataJson));
            }

            return Resimler;
        }

        public void AssetBilgisiDegistir(string yenikonum)
        {
            string folderPath = $"{Konum}";


            string[] jsonFiles = Directory.GetFiles(folderPath, "*.json").OrderBy(dosya => File.GetLastWriteTime(dosya)).ToArray();

            List<AssetData> Resimler = new List<AssetData>();

            foreach (var file in jsonFiles)
            {
                string AssetDataJson = File.ReadAllText(file);
                string resimkonumu = JsonConvert.DeserializeObject<AssetData>(AssetDataJson).asset.path;
                int index = resimkonumu.IndexOf(@"\vott-json-export");
                string relativePath = index != -1 ? resimkonumu.Substring(index) : resimkonumu;
                AssetData AssetJson = JsonConvert.DeserializeObject<AssetData>(AssetDataJson);
                AssetJson.asset.path = $"file:{yenikonum}{relativePath}";
                string AssetJsonS = JsonConvert.SerializeObject(AssetJson, Formatting.Indented);
                File.WriteAllText($"{yenikonum}\\{Path.GetFileNameWithoutExtension(file)}.json", AssetJsonS);

            }

        }
    }
}
