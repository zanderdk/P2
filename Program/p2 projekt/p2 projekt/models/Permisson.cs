using p2_projekt.Enums;
namespace p2_projekt.models
{
    

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
     
        public PermissionLevel OtherUsers { get; set; }
        
        public PermissionLevel PersonalInfo { get; set; }        

        public PermissionLevel Map { get; set; }

        }
    }
