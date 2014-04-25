using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.models;

namespace p2_projekt
{
    public class DatabaseCreation
    {
        Random r = new Random();
        
        
        

        
        int Registreringsnummer = 23914;


        string[] Name = new string[] { "Mette", "Jonas", "Jørgen", "Kasper", "Mads", "Johanne", "Sofie", "Pernille", "Daniel", "Mogens", "Dennis", "Hanne", "Johannes", "Simon", "Jonathan", "Martin", "Allan", "Mathilde", "Egon", "Pia" };
        string[] LastName = new string[] { "Madsen", "Mogensen", "Hansen", "Jackobsen", "Stalone", "Snoep", "Friis", "Frandsen", "Juul", "Karlsen", "Hoffmann", "Andersen", "Larsen", "Hedegaard", "Krog", "Rasmussen", "Toft", "Olsen", "Sved", "Lægteskov" };
        string[] BoatName = new string[] { "The Titania", "HMS Dannebro", "HMS Epangelia", "Dorthe", "Johanna V", "Den Usynkelige II", "Bodil", "Samsung", "Vraget", "Skuden", "Søsanne" };
        string[] info = new string[] { "Der er sæler på pladsen", "Der bor Ænder her", " Vandet er lavt her", "Jørgens Iphone 5 ligger et eller andet sted her", "Den er lidt brændt", "Den er meget beskidt", "Egon ligger ved siden af den", "Gammel Plads", "Alle både der ligger her synker", "Pladsen er grøn" };
        string[] Email = new string[] { "@stupid.com", "@sved.dk", "@hotmail.com", "@gmail.com", "@yahoo.dk", "@blizzard.com", "@maersk.dk", "@apple.dk" };
        string[] Country = new string[] { "Danmark", "Svenskerland", "Norge", "Tyskland", "Frankrig", "Finland", "Rusland", "Nordpolen", "'Merica" };
        string[] Cities = new string[] { "Svedstrup", "Paris", "Oslo", "Malmø", "Skive", "Horsens", "København", "Viborg", "Ulstrup", "Göteborg", "warszawa" };
        string[] AdressP1 = new string[] {"Sved","Kage","Nodre","Faldskærms","Danmarks","Pakke","Ligge","Internet"};
        string[] AdressP2 = new string[] { "vej", "ly", "krattet", "gade" };
        double[] Dimensions = new double[] { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 10.5, 11, 11.5, 12, 12.5, 13, 13.5, 14, 14.5, 15, 15.5, 16, 16.5, 17, 17.5, 18, 18.5, 19, 19.5, 20, 20.5, 21, 21.5, 22, 22.5, 23, 23.5, 24, 24.5, 25 };



        private Member CreateUser()
        {
          
                
                int BirthdayYear = r.Next(1900,2005);
                int BirthdayMonth = r.Next(1,12);
                int BirthdayDay = r.Next(1,28);
                int RegDayYear = r.Next(1900,2014);
                int RegDayMonth = r.Next(1,12);
                int RegDayDay = r.Next(1,28);

                string tempName = Name[r.Next(0, Name.Length)];
                string Password = ""+tempName+r.Next(100,9001);
                string tempEmail = "" + tempName + BirthdayYear + Email[r.Next(0,Email.Length)];
                string phonenumber = "2"+r.Next(2,8)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9);
                

                Member member = new Member((tempName + " " + LastName[r.Next(0, LastName.Length)]), new System.Device.Location.CivicAddress());
                member.Password = Password;
                member.Email = tempEmail;
                member.Phone = phonenumber;
                member.Adress.CountryRegion = Country[r.Next(0, Country.Length)];
                member.Adress.City = Cities[r.Next(0, Cities.Length)];
                member.Adress.AddressLine1 = "" + AdressP1[r.Next(0, AdressP1.Length)] + AdressP2[r.Next(0, AdressP2.Length)]+" "+r.Next(1,500);
                member.Adress.PostalCode = "" + r.Next(1000, 9999);

                // TODO alle skal ikke have søge rettigheder
                member.Permission = new Permission() { MemberInfo = PermissionLevel.Write, search = PermissionLevel.Write, ChangePersonalInfo = PermissionLevel.Write};
                member.Birthday = new DateTime(BirthdayYear,BirthdayMonth,BirthdayDay);
                member.RegistrationDate = new DateTime(RegDayYear, RegDayMonth, RegDayDay);
            
            return member;
        }

        private Boat CreateBoat()
        {
                            
                Boat boat = new Boat()
                { 
                    Name = BoatName[r.Next(0, BoatName.Length)], 
                    RegistrationNumber = "" + Registreringsnummer,
                    Length = Dimensions[r.Next(0, Dimensions.Length)],
                    Width = Dimensions[r.Next(0, Dimensions.Length)]
                };
            
            return boat;
        }

        private BoatSpace CreateBoatSpace()
        {
                
                

                BoatSpace boat_space = new WaterSpace(Dimensions[r.Next(0, Dimensions.Length)], Dimensions[r.Next(0, Dimensions.Length)]);
                boat_space.info = info[r.Next(0, info.Length)];
            
            return boat_space;
        }

        


        public void CreateDataset(UserController uc, int wantedUsers)
        {

            List<User> Users = new List<User>();
            List<Boat> Boats = new List<Boat>();
            
            for (int i = 0; i < wantedUsers; i++)
            {
                Member m = CreateUser();
                Boat b = CreateBoat();
                BoatSpace bs = CreateBoatSpace();
                b.BoatSpace = bs;
                //bs.Boat = b;
                m.Boats.Add(b);
                uc.Add<User>(m);

            }

            

            //Her addes der specifikke medlemmer/både/pladser

        }

        //Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
        //Member alice = new Member("Alice", new System.Device.Location.CivicAddress()) { Password = "test" };
        
    }
}
