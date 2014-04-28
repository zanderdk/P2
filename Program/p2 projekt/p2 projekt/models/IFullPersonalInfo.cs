using System;

namespace p2_projekt.models
{
    public interface IFullPersonalInfo : IBasicPersonalInfo
    {
        string Email { get; set; }
        DateTime Birthday { get; set; }
        DateTime RegistrationDate { get; } //TODO automatisk registrering kun getter
        string MembershipDuration { get; } //TODO calculate shit

    }
}
