using System.IO;
using MyToDoList.Interfaces;
using Newtonsoft.Json;

namespace MyToDoList.DataAccess
{
    public class FileStorer : IObjectStorer
    {
        public void StoreObject(string name, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var filePath = Path.GetTempPath() + name + ".txt";
            File.WriteAllText(filePath, json);
        }
        
        public T LoadObject<T>(string name)
        {
            var filePath = Path.GetTempPath() + name + ".txt";

            if (!File.Exists(filePath))
                return default(T);

            using (var jsonFile = new StreamReader(filePath))
            {
                var json = jsonFile.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}