using Common.Jwt.Enum;

namespace Common.Jwt.Interface;

public interface IIdentityUser
{
    string? UserId { get; }
    string? UserName { get; }
    string? NickName { get; }
    string? UserPhoto { get; }
    string? PhoneType { get; }
    string? Isvalidator { get; }
    string? UserType { get; }
    string? IdentityUserName { get; }
    string? Name { get; }
    string? GivenName { get; }
    string? FamilyName { get; }
    string? MiddleName { get; }
    string? Nickname { get; }
    string? PreferredUsername { get; }
    string? Profile { get; }
    string? Picture { get; }
    string? Website { get; }
    string? Email { get; }
    string? EmailVerified { get; }
    string? Gender { get;  }
    string? Birthdate { get;  }
    string? Zoneinfo { get; }
    string? Locale { get; }
    string? PhoneNumber { get; }
    string? PhoneNumberVerified { get; }
    string? Address { get; }
    string? UpdatedAt { get; }
    string? Role { get; }
    string? Groups { get; }
    string? Permissions { get; }
    string? Custom1 { get; }
    string? Custom2 { get; }
    string? Custom3 { get; }
    string? Custom4 { get; }
    string? Custom5 { get; }
    string? Custom6 { get; }
    string? Custom7 { get; }
    string? Custom8 { get; }
}
