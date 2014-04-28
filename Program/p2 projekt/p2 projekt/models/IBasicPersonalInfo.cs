using System.Device.Location;

namespace p2_projekt.models
{
    public interface IBasicPersonalInfo
    {
        string Phone { get; set; }
        string Name { get; set; }
        CivicAddress Adress { get; set; }
    }
}
