using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public enum PermissionLevel { None, Read, Write }

    public class Permission
    {
        public int PermissionId { get; set; }

        public bool CanRead(PermissionLevel permissionField)
        {
            return permissionField > PermissionLevel.None;
        }

        public bool CanWrite(PermissionLevel permissionField)
        {
            return permissionField == PermissionLevel.Write;
        }

        public PermissionLevel MemberInfo { get; set; }

        
        
        public bool search { get; set; }
        
        public bool ChangePersonalInfo { get; set; }
    }
}
