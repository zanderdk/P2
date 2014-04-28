using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

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
            return string.Format("{0} - {1} - {2}", this.Name, this.Phone, this.Adress.AddressLine1);
        }
    }
    
    
    
    

    
}
