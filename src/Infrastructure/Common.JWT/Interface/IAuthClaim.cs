namespace Common.JWT.Interface;

public interface IAuthClaim
{
    string UserId { get; set; }
    string UserName { get; set; }
    string NickName { get; set; }
    string UserPhoto { get; set; }
    string PhoneType { get; set; }
    string Isvalidator { get; set; }
    string UserType { get; set; }
    string Issuer { get; set; }
    string Name { get; set; }
    string GivenName { get; set; }
    string FamilyName { get; set; }
    string MiddleName { get; set; }
    string Nickname { get; set; }
    string PreferredUsername { get; set; }
    string Profile { get; set; }
    string Picture { get; set; }
    string Website { get; set; }
    string Email { get; set; }
    string EmailVerified { get; set; }
    string Gender { get; set; }
    string Birthdate { get; set; }
    string Zoneinfo { get; set; }
    string Locale { get; set; }
    string PhoneNumber { get; set; }
    string PhoneNumberVerified { get; set; }
    string Address { get; set; }
    string UpdatedAt { get; set; }
    string Role { get; set; }
    string Groups { get; set; }
    string Permissions { get; set; }
    string LoginTime { get; set; }
    string LoginIPAddress { get; set; }
    string TokenType { get; set; }
    string Expiration { get; set; }
    string Custom1 { get; set; }
    string Custom2 { get; set; }
    string Custom3 { get; set; }
    string Custom4 { get; set; }
    string Custom5 { get; set; }
    string Custom6 { get; set; }
    string Custom7 { get; set; }
    string Custom8 { get; set; }
}
