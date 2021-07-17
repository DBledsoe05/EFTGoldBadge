using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Poco
{
    public class Badge
    {
        public int ID { get; set; }
        public List<string> Doors { get; set;}

        public Badge()
        {

        }

        public Badge(List<string> doors)
        {
            Doors = doors;
        }
    }
}
