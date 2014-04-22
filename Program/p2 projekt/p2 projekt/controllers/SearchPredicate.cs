using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.models;
using p2_projekt.WPF;

namespace p2_projekt.controllers
{
    public static class SearchPredicate
    {
        public static Func<User, bool> getPredicat(InfolineController info)
        {
            if (info.Name == "name")
            {
                return x =>
                {
                    if (x.Name.ToLower().Contains(info.Text.ToLower()))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (info.Name == "phone") //TODO only numbers execption
            {
                return x =>
                {
                    if (x.Phone == null)
                    {
                        return false;
                    }

                    if (x.Phone.Contains(info.Text))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (info.Name == "birthday") //TODO evt gør det mulight at søge på fx. kun årstallet
            {
                DateTime test;
                return x =>
                {

                    if (info.Text == "dag/måned/år")
                        return true;

                    if (!DateTime.TryParse(info.Text, out test))
                        return false;

                    if (!(x is IFullPersonalInfo))
                        return false;

                    if ((x as IFullPersonalInfo).Birthday == test)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "email") //TODO only numbers execption
            {
                return x =>
                {
                    if (!(x is IFullPersonalInfo))
                        return false;

                    if ((x as IFullPersonalInfo).Email == null)
                    {
                        return false;
                    }

                    if ((x as IFullPersonalInfo).Email.ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "adresse")
            {
                return x =>
                {
                    if (!(x is IBasicPersonalInfo))
                        return false;

                    if ((x as IBasicPersonalInfo).Adress.AddressLine1 == null)
                    {
                        return false;
                    }

                    if ((x as IBasicPersonalInfo).Adress.AddressLine1.ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "postal")
            {
                return x =>
                {
                    if (!(x is IBasicPersonalInfo))
                        return false;

                    if ((x as IBasicPersonalInfo).Adress.PostalCode == null)
                    {
                        return false;
                    }

                    if ((x as IBasicPersonalInfo).Adress.PostalCode.ToString().ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "country")
            {
                return x =>
                {
                    if (!(x is IBasicPersonalInfo))
                        return false;

                    if ((x as IBasicPersonalInfo).Adress.CountryRegion == null)
                    {
                        return false;
                    }

                    if ((x as IBasicPersonalInfo).Adress.CountryRegion.ToString().ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "memberID")
            {
                return x =>
                {
                    if (!(x is Member))
                        return false;

                    if ((x as Member).MembershipNumber.ToString().Contains(info.Text))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (info.Name == "memberSince") //TODO evt gør det mulight at søge på fx. kun årstallet
            {
                DateTime test;
                return x =>
                {

                    if (info.Text == "dag/måned/år")
                        return true;

                    if (!DateTime.TryParse(info.Text, out test))
                        return false;

                    if (!(x is IFullPersonalInfo))
                        return false;

                    var reg = (x as IFullPersonalInfo).RegistrationDate;

                    if (reg.Date == test.Date)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "isActive")
            {
                return x =>
                {
                    if (!(x is Member))
                        return false;

                    bool test = info.Text.ToLower() == "ja" ? true : false;

                    if ((x as Member).IsActive == test)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "boatOwner")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.User.Name.ToLower().Contains(info.Text.ToLower()))
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatName")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Name.ToLower().Contains(info.Text.ToLower()))
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatID")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(info.Text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.BoatId == id)
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatName")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.BoatSpace != null)
                        {
                            if (b.BoatSpace.info.ToLower().Contains(info.Text.ToLower()))
                                return true;
                        }

                    }

                    return false;

                };
            }

            if (info.Name == "boatLength")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(info.Text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Length == id)
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatWidth")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(info.Text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Width == id)
                            return true;
                    }

                    return false;

                };
            }

            throw new InvalidOperationException();
        }
    }
}
