using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class Permission
    {
        private bool _searchRead;
        private bool _searchWrite;

        public int PermissionId { get; set; }
        public bool member { get; set; }
        public bool readOnlyMember { get; set; }
        public bool search { get; set; }
        public bool SearchWrite { 
            get {
                return _searchWrite;
                } 
            set {
                    if (value == true)
                    {
                        _searchWrite = true;
                        SearchRead = true;
                    }
                }
        }
        public bool SearchRead { 
            get {
                return _searchRead;
        
                }
            set {
                if (value == false)
                {
                    SearchWrite = value;
                }

                 _searchRead = value;
            }
        }
        public bool ChangePersonalInfo { get; set; }
    }
}
