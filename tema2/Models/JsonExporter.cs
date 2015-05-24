using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
namespace tema2.Models
{
    public class JsonExporter :Exporter
    {
        public void Export(List<Bere> beerList)
        {
            string buff = JsonConvert.SerializeObject(beerList, Formatting.Indented);
            File.WriteAllText("C:\\Users\\Flaviu\\Desktop\\Anu III\\PS\\tema1\\tema2\\tema2\\jsonFile.json", buff);

        }
    }
}