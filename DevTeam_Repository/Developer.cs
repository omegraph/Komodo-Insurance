using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repository
{
    public class Developer
    {
        public int DeveloperID { get; set; }
        public string Name { get; set; }
        public bool HasPluralsight { get; set; }

        public Developer() { }

        public Developer(int id, string name, bool hasPluralsight)
        {
            DeveloperID = id;
            Name = name;
            HasPluralsight = hasPluralsight;
        }

    }
}
