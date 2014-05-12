using System;

namespace p2_projekt.models
{
    // has no member ID
    public class HarbourMaster : User, IFullPersonalInfo, ILoginable
    {
        public HarbourMaster()
        {

        }

        public HarbourMaster(string name)
            : base(name)
        {
            RegistrationDate = DateTime.Now;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email
        {
            get;
            set;
        }

        public DateTime Birthday
        {
            get;
            set;
        }

        public DateTime RegistrationDate { get; set; }
        public string MembershipDuration { get { return (DateTime.Now - RegistrationDate).ToString(); } }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is HarbourMaster))
            {
                return false;
            }

            return (obj as HarbourMaster).Username == Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public static bool operator ==(HarbourMaster u1, HarbourMaster u2)
        {
            if (ReferenceEquals(u1, null))
            {
                if (ReferenceEquals(u2, null))
                    return true;
                return false;
            }
            return u1.Equals(u2);
        }

        public static bool operator !=(HarbourMaster u1, HarbourMaster u2)
        {
            return !(u1 == u2);
        }


    }
}
