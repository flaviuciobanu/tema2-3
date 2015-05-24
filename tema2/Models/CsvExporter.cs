using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace tema2.Models
{
    public class CsvExporter:Exporter
    {
        public void Export(List<Bere> beerList)
        {
            string buff = CsvSerializer.GetCSV(beerList);
            CsvSerializer.ExportCSV(buff);
        }
    }
}