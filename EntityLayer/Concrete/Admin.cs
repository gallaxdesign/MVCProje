using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminName { get; set; }

        [StringLength(50)]
        public string AdminSurName { get; set; }
        [StringLength(50)]
        public string AdminUsername { get; set; }

        [StringLength(200)]
        public string AdminPassword { get; set; }
        [StringLength(250)]
        public string AdminImage { get; set; }

        [StringLength(100)]
        public string AdminAbout { get; set; }

        [StringLength(200)]
        public string AdminMail { get; set; }


        [StringLength(1)]
        public string AdminRole { get; set; }

        public bool AdminStatus { get; set; }


    }
}
