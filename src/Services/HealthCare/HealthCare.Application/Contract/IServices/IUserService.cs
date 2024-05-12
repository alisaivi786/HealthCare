using HealthCare.Common.Models.Dtos.Response;

namespace HealthCare.Application.Contract.IServices;

public interface IUserService
{
    List<UserResponse> GetUserDetails();
    void Register();
    void UpdateProfile();
}
