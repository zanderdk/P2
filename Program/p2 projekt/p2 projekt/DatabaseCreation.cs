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


        string[] Navn = new string[] { "Mette", "Jonas", "Jørgen", "Kasper", "Mads", "Johanne", "Sofie", "Pernille", "Daniel", "Mogens", "Dennis", "Hanne", "Johannes", "Simon", "Jonathan", "Martin", "Allan", "Mathilde", "Egon", "Pia" };
        string[] EfterNavn = new string[] { "Madsen", "Mogensen", "Hansen", "Jackobsen", "Stalone", "Snoep", "Friis", "Frandsen", "Juul", "Karlsen", "Hoffmann", "Andersen", "Larsen", "Hedegaard", "Krog", "Rasmussen", "Toft", "Olsen", "Sved", "Lægteskov" };
        string[] BådNavn = new string[] { "The Titania", "HMS Dannebro", "HMS Epangelia", "Dorthe", "Johanna V", "Den Usynkelige II", "Bodil", "Samsung", "Vraget", "Skuden", "Søsanne" };
        string[] info = new string[] { "Der er sæler på pladsen", "Der bor Ænder her", " Vandet er lavt her", "Jørgens Iphone 5 ligger et eller andet sted her", "Den er lidt brændt", "Den er meget beskidt", "Egon ligger ved siden af den", "Gammel Plads", "Alle både der ligger her synker", "Pladsen er grøn" };
        double[] Dimensions = new double[] { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 10.5, 11, 11.5, 12, 12.5, 13, 13.5, 14, 14.5, 15, 15.5, 16, 16.5, 17, 17.5, 18, 18.5, 19, 19.5, 20, 20.5, 21, 21.5, 22, 22.5, 23, 23.5, 24, 24.5, 25 };


        private Member CreateUser()
        {
          
                
                int BirthdayYear = r.Next(1900,2005);
                int BirthdayMonth = r.Next(1,12);
                int BirthdayDay = r.Next(1,31);
                int RegDayYear = r.Next(1900,2014);
                int RegDayMonth = r.Next(1,12);
                int RegDayDay = r.Next(1,31);
                string tempName = Navn[r.Next(0, Navn.Length)];
                string Password = ""+tempName+r.Next(100,9001)+"";
                
                Member member = new Member((tempName + " " + EfterNavn[r.Next(0, EfterNavn.Length)]), new System.Device.Location.CivicAddress());
                member.Password = Password;

                
                // TODO alle skal ikke have søge rettigheder
                member.Permission = new Permission() { MemberInfo = PermissionLevel.Write, search = PermissionLevel.Write, ChangePersonalInfo = PermissionLevel.Write};
                member.Birthday = new DateTime(BirthdayYear,BirthdayMonth,BirthdayDay);
                member.RegistrationDate = new DateTime(RegDayYear, RegDayMonth, RegDayDay);
            
            return member;
        }

        private Boat CreateBoat()
        {
            
                
                Registreringsnummer++;

                Boat boat = new Boat() { 
                    Name = BådNavn[r.Next(0, BådNavn.Length)], 
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
                m.Boats.Add(b);

                uc.Add<User>(m);

            }

            

            //Her addes der specifikke medlemmer/både/pladser

        }

        //Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
        //Member alice = new Member("Alice", new System.Device.Location.CivicAddress()) { Password = "test" };
        
    }
}
