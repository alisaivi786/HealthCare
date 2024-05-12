namespace HealthCare.Application.Contract.IServices;

public interface IAuthenticationService
{
    void AuthenticateUser();
    void AuthorizeAccess();
}
