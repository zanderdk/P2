using p2_projekt.Enums;
namespace p2_projekt.models
{
    

    public class Permission
    {
        // primary key
        public int PermissionId { get; set; }

        public static bool CanRead(EnumPermissionLevel permissionField)
        {
            return permissionField > EnumPermissionLevel.None;
        }

        public static bool CanWrite(EnumPermissionLevel permissionField)
        {
            return permissionField == EnumPermissionLevel.Write;
        }

        public EnumPermissionLevel MemberInfo { get;  set; }
     
        public EnumPermissionLevel Search { get; set; }
        
        public EnumPermissionLevel ChangePersonalInfo { get; set; }
        

        }
    }
