using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class Ispit 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Prijava> Prijave { get; set; } = new List<Prijava>();
    }
}