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
        // primary key
        public int PermissionId { get; set; }

        public static bool CanRead(PermissionLevel permissionField)
        {
            return permissionField > PermissionLevel.None;
        }

        public static bool CanWrite(PermissionLevel permissionField)
        {
            return permissionField == PermissionLevel.Write;
        }

        public PermissionLevel MemberInfo { get;  set; }
     
        public PermissionLevel search { get; set; }
        
        public PermissionLevel ChangePersonalInfo { get; set; }
        

        }
    }
