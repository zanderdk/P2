using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class Permission2
    {
        public string MyProperty { get; set; }
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        bool change;
        User _user;
        public User User {
            get { return _user; }
            set {

                if (change) return;

                change = true;

                if(value == null)
                {
                    _user.Permission2 = null;
                    _user = null;
                }
                else
                {

                }


                change = false;
            }
        }
    }
}
