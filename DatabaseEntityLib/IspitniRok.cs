using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class IspitniRok
    {
        public int ID { get; set; }
        public string Name { get; set; }
//        public bool Regular { get; set; }
//        public DateTime Date { get; set; }
        public ICollection<Prijava> IspitnePrijave { get; set; } = new List<Prijava>();
    }
}
