
using System.Device.Location;

namespace p2_projekt.models
{
    
    public abstract class User
    {
        
        public int UserId { get; set; }// Unique. Only used internally

        public virtual Permission Permission { get; set; }

        

        public User()
        {
        }

        public User(string name) : this()
        {
            Name = name;
        }


        public string Phone
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public CivicAddress Adress
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Name, Phone, Adress.AddressLine1);
        }
    }
    
    
    
    

    
}
