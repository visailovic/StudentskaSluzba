using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntityLib
{
    public class Prijava
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; }

        [Required]
        public int IspitID { get; set; }
        [ForeignKey("IspitID")]
        public Ispit Ispit { get; set; }

        [Required]
        public int IspitniRokID { get; set; }
        [ForeignKey("IspitniRokID")]
        public IspitniRok IspitniRok { get; set; }
    }
}
