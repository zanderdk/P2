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
     
        public PermissionLevel Search { get; set; }
        
        public PermissionLevel ChangePersonalInfo { get; set; }
        

        }
    }
