using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaKB.Classlar.JsonClass
{
    public class Location
    {
        // İsim ve konum bilgisini temsil eden sınıf
        public class NameandLocation
        {
            public string name { get; set; }
            public string path { get; set; }
        }


        public class Locations
        {
            public List<NameandLocation> Location { get; set; }
        }

        public string LocationInfo(int i)
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            return LocationJson.Location[i].path;
        }

        public List<NameandLocation> locationsList()
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            LocationJson.Location.RemoveAll(item => !File.Exists(item.path));

            jsonContent = JsonConvert.SerializeObject(LocationJson, Formatting.Indented);
            File.WriteAllText("Json\\Location.json", jsonContent);

            List<NameandLocation> Locations = LocationJson.Location;
            return Locations;
        }

        public int LocationCount()
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            return LocationJson.Location.Count;
        }

        public void LocationCreate(string isim, string konum)
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            LocationJson.Location.Add(new NameandLocation() { name = isim, path = konum + isim + ".vott" });

            jsonContent = JsonConvert.SerializeObject(LocationJson, Formatting.Indented);
            File.WriteAllText("Json\\Location.json", jsonContent);

            Directory.CreateDirectory(konum + "vott-json-export\\");
        }

        public void LocationAdd(string isim, string konum)
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            LocationJson.Location.Add(new NameandLocation() { name = isim, path = konum });

            jsonContent = JsonConvert.SerializeObject(LocationJson, Formatting.Indented);
            File.WriteAllText("Json\\Location.json", jsonContent);
        }

        public void LocationRemove(int i)
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            LocationJson.Location.RemoveAt(i);

            jsonContent = JsonConvert.SerializeObject(LocationJson, Formatting.Indented);
            File.WriteAllText("Json\\Location.json", jsonContent);
        }

        public void LocationChange(int i,string konum)
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            LocationJson.Location[i] = new NameandLocation() { name = LocationJson.Location[i].name, path = konum };

            jsonContent = JsonConvert.SerializeObject(LocationJson, Formatting.Indented);
            File.WriteAllText("Json\\Location.json", jsonContent);
        }

        public void LocationNameChange(int i,string NewName)
        {
            string jsonContent = File.ReadAllText("Json\\Location.json");
            Locations LocationJson = JsonConvert.DeserializeObject<Locations>(jsonContent);

            LocationJson.Location[i] = new NameandLocation() { name = NewName, path = LocationJson.Location[i].path.Replace(LocationJson.Location[i].name+".vott", NewName + ".vott") };

            jsonContent = JsonConvert.SerializeObject(LocationJson, Formatting.Indented);
            File.WriteAllText("Json\\Location.json", jsonContent);
        }
    }
}
