using System.Collections.ObjectModel;

namespace p2_projekt.models
{
    public class Guest : User, ISailor
    {
        public Guest()
        {
            Boats = new ObservableCollection<Boat>();
            Travels = new ObservableCollection<Travel>();
        }


        public bool HasPaid { get; set; } //TODO Overvej at flytte denne til ny interface f.eks. IRenter

        public virtual ObservableCollection<Travel> Travels
        {
            get;
            set;
        }

        public virtual ObservableCollection<Boat> Boats
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Guest))
            {
                return false;
            }

            return (obj as Guest).UserId == UserId;
        }

        public override int GetHashCode()
        {
            return UserId.GetHashCode();
        }

        public static bool operator ==(Guest u1, Guest u2)
        {
            if (ReferenceEquals(u1, null))
            {
                if (ReferenceEquals(u2, null))
                    return true;
                return false;
            }
            return u1.Equals(u2);
        }

        public static bool operator !=(Guest u1, Guest u2)
        {
            return !(u1 == u2);
        }
    }
}
