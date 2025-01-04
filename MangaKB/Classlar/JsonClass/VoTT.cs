using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MangaKB.Classlar.JsonClass.AssetJson;
using static MangaKB.Classlar.JsonClass.Export;

namespace MangaKB.Classlar.JsonClass
{
    public class VoTT(string path)
    {
        public class providerOptions
        {
            public string Path { get; set; }
        }

        public class Connection
        {
            public string providerType { get; set; }
            public providerOptions providerOptions { get; set; }
        }


        public class tag
        {
            public string name { get; set; }
            public string color { get; set; }
        }

        public class size
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class assets
        {
            public string format { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string path { get; set; }
            public size size { get; set; }
            public int state { get; set; }
            public int type { get; set; }
        }

        public class exportFormat
        {
            public string providerType { get; set; }
            public providerOptions providerOptions { get; set; }
        }

        public class root
        {
            public string name { get; set; }
            public string securityToken { get; set; }
            public Connection Connection { get; set; }
            public List<tag> tags { get; set; }
            public exportFormat exportFormat { get; set; }
            public string version { get; set; }
            public string lastVisitedAssetId { get; set; }
            public Dictionary<string, assets> assets { get; set; }
        }


        public void Save(AssetJson.Asset Asset)
        {
            assets assets = new assets()
            {
                format = Asset.format,
                id = Asset.id,
                name = Asset.name,
                path = Asset.path,
                size = new size()
                {
                    height = Asset.size.height,
                    width = Asset.size.width
                },
                state = Asset.state,
                type = Asset.type
            };

            string VoTTSs = File.ReadAllText(path);

            root VoTTs = JsonConvert.DeserializeObject<root>(VoTTSs);

            try
            {
                VoTTs.assets.Add(assets.id, assets);
            }
            catch
            {
                VoTTs.assets.Remove(assets.id);
                VoTTs.assets.Add(assets.id, assets);
            }


            string updatedJson = JsonConvert.SerializeObject(VoTTs, Formatting.Indented);

            File.WriteAllText(path, updatedJson);

        }

        public void TagEkle(string Name , string Color)
        {
            root VottJson = JsonConvert.DeserializeObject<root>(File.ReadAllText(path));

            List<List<string>> Tags = new List<List<string>>();

            VottJson.tags.Add(new tag() { name = Name, color = Color });

            string VoTTSs = JsonConvert.SerializeObject(VottJson, Formatting.Indented);

            File.WriteAllText(path, VoTTSs);
        }

        public void TagSilme(int i)
        {
            root VottJson = JsonConvert.DeserializeObject<root>(File.ReadAllText(path));

            List<List<string>> Tags = new List<List<string>>();

            VottJson.tags.RemoveAt(i);

            string VoTTSs = JsonConvert.SerializeObject(VottJson, Formatting.Indented);

            File.WriteAllText(path, VoTTSs);
        }

        public List<List<string>> Tags()
        {
            root ExportJson = JsonConvert.DeserializeObject<root>(File.ReadAllText(path));

            List<List<string>> Tags = new List<List<string>>();

            foreach (tag Tag in ExportJson.tags)
            {
                Tags.Add(new List<string> { Tag.name, Tag.color });
            }

            return Tags;

        }

        public root Export()
        {

            string VoTTSs = File.ReadAllText(path);

            root VoTTs = JsonConvert.DeserializeObject<root>(VoTTSs);

            return VoTTs;
        }

        public void KonumBilgisiDegistir(string yenikonum)
        {
            root VottJson = JsonConvert.DeserializeObject<root>(File.ReadAllText(path));

            VottJson.Connection.providerOptions.Path = yenikonum + "\\";
            VottJson.exportFormat.providerOptions.Path = yenikonum + "\\" + "vott-json-export\\";
            
            string VoTTSs = JsonConvert.SerializeObject(VottJson, Formatting.Indented);

            File.WriteAllText($"{yenikonum}\\{Path.GetFileNameWithoutExtension(path)}.vott", VoTTSs);
        }

        public void LocationNameChange(string NewName)
        {
            root VottJson = JsonConvert.DeserializeObject<root>(File.ReadAllText(path));

            VottJson.name = NewName;

            string VoTTSs = JsonConvert.SerializeObject(VottJson, Formatting.Indented);

            File.WriteAllText($"{VottJson.Connection.providerOptions.Path}\\{NewName}.vott", VoTTSs);
        }

        public void olustur(string Name, string AssetPath)
        {
            string VoTTSs = File.ReadAllText("Json\\EmptyVott.json");
            root VoTTs = JsonConvert.DeserializeObject<root>(VoTTSs);
            VoTTs.name = Name;
            VoTTs.securityToken = Name + "Token";
            VoTTs.Connection.providerOptions.Path = AssetPath;
            VoTTs.exportFormat.providerOptions.Path = AssetPath + "vott-json-export\\";
            VoTTSs = JsonConvert.SerializeObject(VoTTs, Formatting.Indented);
            File.WriteAllText(AssetPath + "" + Name + ".vott", VoTTSs);
            
        }

        public string Location()
        {
            string VoTTSs = File.ReadAllText(path);
            root VoTTs = JsonConvert.DeserializeObject<root>(VoTTSs);
            return VoTTs.Connection.providerOptions.Path;
        }

        public string Name()
        {
            string VoTTSs = File.ReadAllText(path);
            root VoTTs = JsonConvert.DeserializeObject<root>(VoTTSs);
            return VoTTs.name;
        }



    }
}
