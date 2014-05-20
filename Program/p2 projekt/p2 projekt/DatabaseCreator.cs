using System;
using System.Collections.Generic;
using p2_projekt.models;
using p2_projekt.Enums;

namespace p2_projekt
{
    public class DatabaseCreator
    {
        Random r = new Random();
        
        int Registreringsnummer = 23914;

        readonly string[] _name = { "Mette", "Jonas", "Jørgen", "Kasper", "Mads", "Johanne", "Sofie", "Pernille", "Daniel", "Mogens", "Dennis", "Hanne", "Johannes", "Simon", "Jonathan", "Martin", "Allan", "Mathilde", "Egon", "Pia" };
        readonly string[] _lastName = { "Madsen", "Mogensen", "Hansen", "Jackobsen", "Stalone", "Snoep", "Friis", "Frandsen", "Juul", "Karlsen", "Hoffmann", "Andersen", "Larsen", "Hedegaard", "Krog", "Rasmussen", "Toft", "Olsen", "Lægteskov" };
        readonly string[] _boatName = { "The Titania", "HMS Dannebro", "HMS Epangelia", "Dorthe", "Johanna V", "Den Usynkelige II", "Bodil", "Samsung", "Vraget", "Skuden", "Søsanne" };
        readonly string[] _info = { "Der er sæler på pladsen", "Der bor Ænder her", " Vandet er lavt her", "Jørgens Iphone 5 ligger et eller andet sted her", "Den er lidt brændt", "Den er meget beskidt", "Egon ligger ved siden af den", "Gammel Plads", "Alle både der ligger her synker", "Pladsen er grøn" };
        readonly string[] _email = { "@smartgit.com", "@youtube.dk", "@hotmail.com", "@gmail.com", "@yahoo.dk", "@blizzard.com", "@maersk.dk", "@apple.dk" };
        readonly string[] _country = { "Danmark", "Sverige", "Norge", "Tyskland", "Frankrig", "Finland", "Rusland", "Spanien", "Holland" };
        readonly string[] _cities = { "Svenstrup", "Paris", "Oslo", "Odense", "Skive", "Horsens", "København", "Viborg", "Ulstrup", "Göteborg", "Warszawa" };
        readonly string[] _adressP1 = {"Majs","Kage","Nodre","Faldskærms","Danmarks","Pakke","Ligge","Internet"};
        readonly string[] _adressP2 = { "vej", "ly", "krattet", "gade" };
        readonly double[] _dimensions = { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 10.5, 11, 11.5, 12, 12.5, 13, 13.5, 14, 14.5, 15, 15.5, 16, 16.5, 17, 17.5, 18, 18.5, 19, 19.5, 20, 20.5, 21, 21.5, 22, 22.5, 23, 23.5, 24, 24.5, 25 };

        private Member CreateUser()
        {                
                int birthdayYear = r.Next(1900,2005);
                int birthdayMonth = r.Next(1,12);
                int birthdayDay = r.Next(1,28);
                int regDayYear = r.Next(1900,2014);
                int regDayMonth = r.Next(1,12);
                int regDayDay = r.Next(1,28);

                string tempName = _name[r.Next(0, _name.Length)];
                string password = ""+tempName+r.Next(1000,9001);
                string tempEmail = "" + tempName + birthdayYear + _email[r.Next(0,_email.Length)];
                string phonenumber = "2"+r.Next(2,8)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9)+r.Next(0,9);
                

                Member member = new Member((tempName + " " + _lastName[r.Next(0, _lastName.Length)]), new System.Device.Location.CivicAddress());
                member.Password = password;
                member.Email = tempEmail;
                member.Phone = phonenumber;
                member.Adress.CountryRegion = _country[r.Next(0, _country.Length)];
                member.Adress.City = _cities[r.Next(0, _cities.Length)];
                member.Adress.AddressLine1 = "" + _adressP1[r.Next(0, _adressP1.Length)] + _adressP2[r.Next(0, _adressP2.Length)]+" "+r.Next(1,500);
                member.Adress.PostalCode = "" + r.Next(1000, 9999);

                member.Permission = new Permission() { OtherUsers = PermissionLevel.None, Map = PermissionLevel.Read,  PersonalInfo = PermissionLevel.Write};
                member.Birthday = new DateTime(birthdayYear,birthdayMonth,birthdayDay);
                member.RegistrationDate = new DateTime(regDayYear, regDayMonth, regDayDay);
            
            return member;
        }

        private Boat CreateBoat()
        {
                            
                Boat boat = new Boat()
                { 
                    Name = _boatName[r.Next(0, _boatName.Length)], 
                    RegistrationNumber = "" + Registreringsnummer,
                    Length = _dimensions[r.Next(0, _dimensions.Length)],
                    Width = _dimensions[r.Next(0, _dimensions.Length)]
                    
                };
            
            return boat;
        }

        private BoatSpace CreateBoatSpace()
        {
                BoatSpace boat_space = new WaterSpace(_dimensions[r.Next(0, _dimensions.Length)], _dimensions[r.Next(0, _dimensions.Length)]);
                boat_space.Info = _info[r.Next(0, _info.Length)];
            
            return boat_space;
        }

        


        public void CreateDataset(DALController uc, int wantedUsers)
        {
            int numberOfDefaultUsers = 7;
            int numberOfSpaces = 36;
            List<User> Users = new List<User>();
            List<Boat> Boats = new List<Boat>();
            List<BoatSpace> BoatSpaces = new List<BoatSpace>();


            Member TestMember1 = new Member("Anders Andersen", new System.Device.Location.CivicAddress(), 1);
            TestMember1.Birthday = new DateTime(2000, 01, 01);
            TestMember1.RegistrationDate = new DateTime(2000, 01, 01);
            TestMember1.Password = "testpass";
            TestMember1.Email = "test1@emailtest.isActive";
            TestMember1.Phone = "00000001";
            TestMember1.Adress.CountryRegion = "Danmark";
            TestMember1.Adress.City = "Grenå";
            TestMember1.Adress.AddressLine1 = "Testervej 1";
            TestMember1.Adress.PostalCode = "8464";
            TestMember1.Permission = new Permission() { PersonalInfo = PermissionLevel.None, Map = PermissionLevel.Read, OtherUsers = PermissionLevel.None };
            Boat b1 = CreateBoat();
            b1.User = TestMember1;
            b1.BoatSpace = CreateBoatSpace();
            TestMember1.Boats.Add(b1);
            uc.Add<User>(TestMember1);

            Member TestMember2 = new Member("Bente Bent", new System.Device.Location.CivicAddress(), 2);
            TestMember2.Birthday = new DateTime(2000, 01, 01);
            TestMember2.RegistrationDate = new DateTime(2000, 01, 01);
            TestMember2.Password = "testpass";
            TestMember2.Email = "test2@emailtest.isActive";
            TestMember2.Phone = "00000002";
            TestMember2.Adress.CountryRegion = "Danmark";
            TestMember2.Adress.City = "Grenå";
            TestMember2.Adress.AddressLine1 = "Testervej 2";
            TestMember2.Adress.PostalCode = "8464";
            TestMember2.Permission = new Permission() { PersonalInfo = PermissionLevel.Write, Map = PermissionLevel.Read, OtherUsers = PermissionLevel.Read };
            Boat b2 = CreateBoat();
            b2.User = TestMember2;
            b2.BoatSpace = CreateBoatSpace();
            TestMember2.Boats.Add(b2);
            uc.Add<User>(TestMember2);

            Member TestMember3 = new Member("Casper Christensen", new System.Device.Location.CivicAddress(), 3);
            TestMember3.Birthday = new DateTime(2000, 01, 01);
            TestMember3.RegistrationDate = new DateTime(2000, 01, 01);
            TestMember3.Password = "testpass";
            TestMember3.Email = "test3@emailtest.isActive";
            TestMember3.Phone = "00000003";
            TestMember3.Adress.CountryRegion = "Danmark";
            TestMember3.Adress.City = "Grenå";
            TestMember3.Adress.AddressLine1 = "Testervej 3";
            TestMember3.Adress.PostalCode = "8464";
            TestMember3.Permission = new Permission() { PersonalInfo = PermissionLevel.Write, Map = PermissionLevel.Write, OtherUsers = PermissionLevel.Write };
            b1 = CreateBoat();
            b1.User = TestMember3;
            b1.BoatSpace = CreateBoatSpace();
            TestMember3.Boats.Add(b1);
            uc.Add<User>(TestMember3);

            Member Havnefogede = new Member("Havnefogeden", new System.Device.Location.CivicAddress(), 4);
            Havnefogede.Birthday = new DateTime(2000, 01, 01);
            Havnefogede.RegistrationDate = new DateTime(2000, 01, 01);
            Havnefogede.Password = "testpass";
            Havnefogede.Permission = new Permission() { PersonalInfo = PermissionLevel.Write, Map = PermissionLevel.Write, OtherUsers = PermissionLevel.Write };
            uc.Add<User>(Havnefogede);

            Member JohanneHoffmann = new Member("Johanne Hoffmann", new System.Device.Location.CivicAddress(), 5);
            JohanneHoffmann.Birthday = new DateTime(2000, 01, 01);
            JohanneHoffmann.RegistrationDate = new DateTime(2000, 01, 01);
            JohanneHoffmann.Password = "testpass";
            JohanneHoffmann.Email = "Johanne@mail.dk";
            JohanneHoffmann.Phone = "22 95 41 87";
            JohanneHoffmann.Adress.CountryRegion = "Danmark";
            JohanneHoffmann.Adress.City = "Odense";
            JohanneHoffmann.Adress.AddressLine1 = "H.C Andersensvej 9";
            JohanneHoffmann.Adress.PostalCode = "8464";
            JohanneHoffmann.Permission = new Permission() { PersonalInfo = PermissionLevel.Write, Map = PermissionLevel.Write, OtherUsers = PermissionLevel.Write };
            b1 = CreateBoat();
            b1.User = JohanneHoffmann;
            b1.Name = "Den Usynkelige II";
            b1.BoatSpace = CreateBoatSpace();
            JohanneHoffmann.Boats.Add(b1);
            uc.Add<User>(JohanneHoffmann);

            Member Johanne1 = new Member("Johanne Snoep", new System.Device.Location.CivicAddress(), 6);
            Johanne1.Birthday = new DateTime(2000, 01, 01);
            Johanne1.RegistrationDate = new DateTime(2000, 01, 01);
            Johanne1.Password = "testpass";
            Johanne1.Email = "JohanneSnoep@mail.dk";
            Johanne1.Phone = "22 26 48 88";
            Johanne1.Adress.CountryRegion = "Danmark";
            Johanne1.Adress.City = "Viborg";
            Johanne1.Adress.AddressLine1 = "Skovkrattet 39";
            Johanne1.Adress.PostalCode = "8840";
            Johanne1.Permission = new Permission() { PersonalInfo = PermissionLevel.Write, Map = PermissionLevel.Read, OtherUsers = PermissionLevel.Read };
            b1 = CreateBoat();
            b1.User = Johanne1;
            b1.BoatSpace = CreateBoatSpace();
            Johanne1.Boats.Add(b1);
            uc.Add<User>(Johanne1);

            Member Johanne2 = new Member("Johanne Friis", new System.Device.Location.CivicAddress(), 7);
            Johanne2.Birthday = new DateTime(2000, 01, 01);
            Johanne2.RegistrationDate = new DateTime(2000, 01, 01);
            Johanne2.Password = "testpass";
            Johanne2.Email = "JohanneFriis@mail.dk";
            Johanne2.Phone = "23 95 85 13";
            Johanne2.Adress.CountryRegion = "Danmark";
            Johanne2.Adress.City = "København";
            Johanne2.Adress.AddressLine1 = "Danmarksvej 4";
            Johanne2.Adress.PostalCode = "1200";
            Johanne2.Permission = new Permission() { PersonalInfo = PermissionLevel.Write, Map = PermissionLevel.Read, OtherUsers = PermissionLevel.Read };
            b1 = CreateBoat();
            b1.User = Johanne2;
            b1.BoatSpace = CreateBoatSpace();
            Johanne2.Boats.Add(b1);
            uc.Add<User>(Johanne2);


            for (int i = 0; i < numberOfSpaces - numberOfDefaultUsers; i++ )
            {
                BoatSpace bs = CreateBoatSpace();
                BoatSpaces.Add(bs);
                uc.Add(bs);
            }


                for (int i = 0; i < wantedUsers - numberOfDefaultUsers; i++)
                {
                    Member m = CreateUser();
                    Boat b = CreateBoat();
                    b.User = m;
                    b.BoatSpace = BoatSpaces[i];
                    m.Boats.Add(b);
                    uc.Add<User>(m);
                }

            

            //Her addes der specifikke medlemmer/både/pladser

        }

        

        //Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
        //Member alice = new Member("Alice", new System.Device.Location.CivicAddress()) { Password = "isActive" };
        
    }
}
