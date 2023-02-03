using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityRecruitment.App.Concrete;
using Newtonsoft.Json;
using UniversityRecruitment.Domain.Entity;
using System.Runtime.CompilerServices;

namespace UniversityRecruitment.App.Managers
{
    public static class ToFileManager
    {
        public static void WriteToJsonFile(string path, List<Item> itemsList)
        {
            using StreamWriter sw = new StreamWriter(path);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, itemsList);
            }
        }
        public static List<Item> ReadJsonFile(string path)
        {
                string json = File.ReadAllText(path);
                var items = JsonConvert.DeserializeObject<List<Item>>(json);
                return items;
        }


    }
}
