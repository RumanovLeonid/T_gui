using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Terminal_TODO
{
    class JSONLoadSave : ITodoLoadSave
    {
        public List<Todo> Load()
        {
            string filename = ConfigurationManager.AppSettings["filename"];
            
            List<Todo> _;
           
            using (StreamReader streamreader = new(filename))
            {
                string JsonData = streamreader.ReadToEnd();
                _ = JsonConvert.DeserializeObject<List<Todo>>(JsonData);
            }

            return _;
        }

        public void Save(List<Todo> todos)
        {
            string filename = ConfigurationManager.AppSettings["filename"];

            string _ = JsonConvert.SerializeObject
                (todos.ToArray(), Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filename, _);
        }
    }
}
