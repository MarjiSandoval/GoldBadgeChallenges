using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class Badge
    {
        public Badge() {}
        public Badge(int badgeNumber, List<string> doors )
        {
            BadgeNumber = badgeNumber;
            Doors = doors;
        }

       
        public int BadgeNumber { get; set; }
        public List<string> Doors { get; set; }

      
    }
}
