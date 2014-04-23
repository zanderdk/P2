using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.models;

namespace p2_projekt
{
    public static class DatabaseAddeClass
    {
        Random r = new Random();
        
        
        int WantedUsers = 50;
        int UserCount = 0;
        int WantedBoats = 50;
        int BoatCount = 0;
        int WantedBoatSpaces = 50;
        int BoatSpaceCount = 0;

        int UserTempID;
        int BoatTempID;
        int BoatSpaceTempID;
        
        int Registreringsnummer = 23914;


        public List<Member> Bruger()
        {
            List<Member> Members = new List<Member>();
            while(UserCount<WantedUsers)
            {
                string[] Navn = new string[] {"Mette", "Jonas", "Jørgen", "Kasper", "Mads", "Johanne", "Sofie", "Pernille","Daniel","Mogens","Dennis","Hanne","Johannes","Simon","Jonathan","Martin","Allan","Mathilde","Egon","Pia"};
                string[] EfterNavn = new string[] {"Madsen","Mogensen","Hansen","Jackobsen","Stalone","Snoep","Friis","Frandsen","Juul","Karlsen","Hoffmann","Andersen","Larsen","Hedegaard","Krog","Rasmussen","Toft","Olsen","Sved","Lægteskov"};
                int BirthdayA = r.Next(1900,2005);
                int BirthdayB = r.Next(1,12);
                int BirthdayC = r.Next(1,31);
                int RegDayA = r.Next(1900,2014);
                int RegDayB = r.Next(1,12);
                int RegDayC = r.Next(1,31);
                string Password1 = ""+Navn[r.Next(0,Navn.Length)]+r.Next(100,9001)+"";
                Member member_ = new Member((Navn[r.Next(0, Navn.Length)] + " " + EfterNavn[r.Next(0, EfterNavn.Length)]), new System.Device.Location.CivicAddress());
                member_.Password = Password1;
                member_.Permission = new Permission() { MemberInfo = PermissionLevel.Write};
                member_.Birthday = new DateTime(BirthdayA,BirthdayB,BirthdayC);
                member_.RegistrationDate = new DateTime(RegDayA, RegDayB, RegDayC);
                Members.Add(member_);
                UserCount++;
            }
            return Members;
        }

        public List<Boat> Båd()
        {
            List<Boat> Boats = new List<Boat>();
            while (BoatCount < WantedBoats)
            {
                string[] BådNavn = new string[] { "The Titania", "HMS Dannebro", "HMS Epangelia", "Dorthe", "Johanna V", "Den Usynkelige II", "Bodil", "Samsung", "Vraget", "Skuden", "Søsanne" };
                Registreringsnummer++;

                Boat boat_ = new Boat() { Name = BådNavn[r.Next(1, BådNavn.Length)], RegistrationNumber = ("" + Registreringsnummer) };
                Boats.Add(boat_);
                BoatCount++;
            }
            return Boats;
        }

        public List<BoatSpace> BådPlads()
        {
            List<BoatSpace> BoatSpaces = new List<BoatSpace>();
            while (BoatSpaceCount < WantedBoatSpaces)
            {
                double[] Bredde = new double[] { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 10.5, 11, 11.5, 12, 12.5, 13, 13.5, 14, 14.5, 15, 15.5, 16, 16.5, 17, 17.5, 18, 18.5, 19, 19.5, 20, 20.5, 21, 21.5, 22, 22.5, 23, 23.5, 24, 24.5, 25 };
                double[] Længde = new double[] { 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10, 10.5, 11, 11.5, 12, 12.5, 13, 13.5, 14, 14.5, 15, 15.5, 16, 16.5, 17, 17.5, 18, 18.5, 19, 19.5, 20, 20.5, 21, 21.5, 22, 22.5, 23, 23.5, 24, 24.5, 25 };
                string[] info = new string[] { "Der er sæler på pladsen", "Der bor Ænder her", " Vandet er lavt her", "Jørgens Iphone 5 ligger et eller andet sted her", "Den er lidt brændt", "Den er meget beskidt", "Egon ligger ved siden af den", "Gammel Plads", "Alle både der ligger her synker", "Pladsen er grøn" };

                BoatSpace boat_space = new WaterSpace(Længde[r.Next(0, Længde.Length)], Bredde[r.Next(0, Bredde.Length)]);
                boat_space.info = info[r.Next(0, info.Length)];
                BoatSpaces.Add(boat_space);
                BoatSpaceCount++;
            }
            return BoatSpaces;
        }
        public void addToDataBase()
        {
            UserController adding = new UserController(new Utilities.Database());
            List<Member> Members = Bruger();
            List<Boat> Boats = Båd();
            List<BoatSpace> BoatSpaces = BådPlads();
                        
            foreach(Member m in Members)
            {
                adding.Add(m);
            }

            foreach(Boat b in Boats)
            {
                adding.Add(b);
            }

            foreach(BoatSpace bs in BoatSpaces)
            {
                adding.Add(bs);
            }

            //Her addes der specifikke medlemmer/både/pladser

        }

        //Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
        //Member alice = new Member("Alice", new System.Device.Location.CivicAddress()) { Password = "test" };
        
    }
}
