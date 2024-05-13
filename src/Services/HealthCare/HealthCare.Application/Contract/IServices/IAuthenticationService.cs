namespace HealthCare.Application.Contract.IServices;

public interface IAuthenticationService
{
    object AuthenticateUser();
    void AuthorizeAccess();
}
