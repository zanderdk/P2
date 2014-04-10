using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class Permissions
    {
        [Key]
        public int UserId { get; set; }
        public bool member { get; set; }
        public bool readOnlyMember { get; set; }
        public bool search { get; set; }
        public bool ChangePersonalInfo { get; set; }
    }
}
