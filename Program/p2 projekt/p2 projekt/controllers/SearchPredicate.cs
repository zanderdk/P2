using System;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    public static class SearchPredicate
    {
        public static Func<User, bool> GetPredicate(string name, string text)
        {
            if (name == "name")
            {
                return x =>
                {
                    if (x.Name.ToLower().Contains(text.ToLower()))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (name == "phone") //TODO only numbers execption
            {
                return x =>
                {
                    if (x.Phone == null)
                    {
                        return false;
                    }

                    if (x.Phone.Contains(text))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (name == "birthday") //TODO evt gør det mulight at søge på fx. kun årstallet
            {
                DateTime test;
                return x =>
                {

                    if (text == "dag/måned/år")
                        return true;

                    if (!DateTime.TryParse(text, out test))
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

            if (name == "email") //TODO only numbers execption
            {
                return x =>
                {
                    if (!(x is IFullPersonalInfo))
                        return false;

                    if ((x as IFullPersonalInfo).Email == null)
                    {
                        return false;
                    }

                    if ((x as IFullPersonalInfo).Email.ToLower().Contains(text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (name == "adresse")
            {
                return x =>
                {

                    if (x.Adress.AddressLine1 == null)
                    {
                        return false;
                    }

                    if (x.Adress.AddressLine1.ToLower().Contains(text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (name == "postal")
            {
                return x =>
                {

                    if (x.Adress.PostalCode == null)
                    {
                        return false;
                    }

                    if (x.Adress.PostalCode.ToString().ToLower().Contains(text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (name == "country")
            {
                return x =>
                {

                    if (x.Adress.CountryRegion == null)
                    {
                        return false;
                    }

                    if (x.Adress.CountryRegion.ToString().ToLower().Contains(text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (name == "memberID")
            {
                return x =>
                {
                    if (!(x is Member))
                        return false;

                    if ((x as Member).MembershipNumber.ToString().Contains(text))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (name == "memberSince") //TODO evt gør det mulight at søge på fx. kun årstallet
            {
                DateTime test;
                return x =>
                {

                    if (text == "dag/måned/år")
                        return true;

                    if (!DateTime.TryParse(text, out test))
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

            if (name == "isActive")
            {
                return x =>
                {
                    if (!(x is Member))
                        return false;

                    bool test = text.ToLower() == "ja"; // TODO test skal renames

                    if ((x as Member).IsActive == test)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (name == "boatOwner")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.User.Name.ToLower().Contains(text.ToLower()))
                            return true;
                    }

                    return false;

                };
            }

            if (name == "boatName")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Name.ToLower().Contains(text.ToLower()))
                            return true;
                    }

                    return false;

                };
            }

            if (name == "boatID")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.BoatId.ToString().Contains(id.ToString()))
                            return true;
                    }

                    return false;

                };
            }

            if (name == "boatName")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.BoatSpace != null)
                        {
                            if (b.BoatSpace.Info.ToLower().Contains(text.ToLower()))
                                return true;
                        }

                    }

                    return false;

                };
            }

            if (name == "boatLength")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(text, out id))
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

            if (name == "boatWidth")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(text, out id))
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
