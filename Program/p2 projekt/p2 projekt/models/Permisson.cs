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
     
        public EnumPermissionLevel OtherUsers { get; set; }
        
        public EnumPermissionLevel PersonalInfo { get; set; }        

        }
    }
