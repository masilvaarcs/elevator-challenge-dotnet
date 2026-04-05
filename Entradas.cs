using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProvaAdmissionalCSharpApisul
{
    public class Entradas
    {
        private string path { get; set; }
        private string jsonString { get; set; }

        public List<ElevadorModel> RecebeEntradas()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            if (!string.IsNullOrEmpty(parentDirectory))
            {
                parentDirectory = parentDirectory.Replace("\\bin\\Debug", "\\dados");
                this.path = Path.Combine(parentDirectory, "input.json");
            }
            List<ElevadorModel> inputs = new List<ElevadorModel>();

            this.jsonString = File.ReadAllText(path);

            inputs = JsonConvert.DeserializeObject<List<ElevadorModel>>(jsonString);

            return inputs;
        }
    }
}