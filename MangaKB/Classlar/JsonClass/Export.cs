using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MangaKB.Classlar.JsonClass.VoTT;


namespace MangaKB.Classlar.JsonClass
{
    public class Export(string Konum, string Name)
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
            public double left { get; set; }
            public double top { get; set; }
            public double width { get; set; }
            public double height { get; set; }
        }

        public class Point
        {
            public double x { get; set; }
            public double y { get; set; }
        }

        public class Project
        {
            public string name { get; set; }
            public string securityToken { get; set; }
            public List<Tag> tags { get; set; }
            public string version { get; set; }
            public string lastVisitedAssetId { get; set; }
            public Dictionary<string, AssetJson.AssetData> assets { get; set; }
        }

        public class VideoSettings
        {
            public int frameExtractionRate { get; set; }
        }

        public class Tag
        {
            public string name { get; set; }
            public string color { get; set; }
        }

        public class ActiveLearningSettings
        {
            public string modelPathType { get; set; }
            public bool autoDetect { get; set; }
            public bool predictTag { get; set; }
        }

        

        public void Save(AssetJson.AssetData AssetDataJson)
        {
            string ExportJsonS = File.ReadAllText($"{Konum}vott-json-export\\{Name}-export.json");

            Project ExportJson = JsonConvert.DeserializeObject<Project>(ExportJsonS);

            try
            {
                ExportJson.assets.Add(AssetDataJson.asset.id, AssetDataJson);
            }
            catch
            {
                ExportJson.assets.Remove(AssetDataJson.asset.id);
                ExportJson.assets.Add(AssetDataJson.asset.id, AssetDataJson);
            }

            string updatedJson = JsonConvert.SerializeObject(ExportJson, Formatting.Indented);

            File.WriteAllText($"{Konum}vott-json-export\\{Name}-export.json", updatedJson);

        }
        new List<Tag> tags = new List<Tag>();

        public void export()
        {

            foreach (var tag in new VoTT(Konum + "" + Name + ".vott").Export().tags)
            {
                tags.Add(new Tag() { color = tag.color, name = tag.name });
            }

            var assets = new Dictionary<string, AssetJson.AssetData>();

            foreach (var assetData in new AssetJson(Konum).ResimLer())
            {
                assets.Add(assetData.asset.id, assetData);  // Use asset.id as the key
            }

            Project project = new Project()
            {
                name = new VoTT(Konum + "" + Name + ".vott").Export().name,
                securityToken = new VoTT(Konum + "" + Name + ".vott").Export().securityToken,
                tags = tags,
                version = new VoTT(Konum + "" + Name + ".vott").Export().version,
                lastVisitedAssetId = new VoTT(Konum + "" + Name + ".vott").Export().lastVisitedAssetId,
                assets = assets
            };

            string ExportJsonS = JsonConvert.SerializeObject(project, Formatting.Indented);

            File.WriteAllText($"{Konum}vott-json-export\\{Name}-export.json", ExportJsonS);



        }

        public List<string> Denetim()
        {

            string ExportJsonS = File.ReadAllText($"{Konum}vott-json-export\\{Name}-export.json");

            Project ExportJson = JsonConvert.DeserializeObject<Project>(ExportJsonS);

            List<string> Denetim = new List<string>();

            foreach (string Name in ExportJson.assets.Keys)
            {
                Denetim.Add(Name);
            }

            return Denetim;

        }

        public DateTime DosyaTarihi()
        {
            return File.GetLastWriteTime($"{Konum}vott-json-export\\{Name}-export.json");
        }
    }
}

