using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }
        public string PersonName { get; set; }
        public string PersonDesc { get; set; }
        public string TalentTitle{ get; set; }
        public string TalentPercent { get; set; }
    }
}
