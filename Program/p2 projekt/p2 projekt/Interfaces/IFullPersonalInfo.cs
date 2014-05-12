using System;

namespace p2_projekt.models
{
    public interface IFullPersonalInfo
    {
        string Email { get; set; }
        DateTime Birthday { get; set; }
        DateTime RegistrationDate { get; }
        string MembershipDuration { get; }

    }
}
