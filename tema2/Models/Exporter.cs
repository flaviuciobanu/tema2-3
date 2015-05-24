using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tema2.Models
{
   public interface Exporter
    {
       void Export(List<Bere> beerList);
    }
}
