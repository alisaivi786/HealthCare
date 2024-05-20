using HealthCare.Common.Models.Dtos.Response;
using HealthCare.Domain.Person;

namespace HealthCare.Infrastructure.Services;

public class UserService(IMapper mapper) : IUserService
{
    private readonly IMapper mapper = mapper;
    public void Register()
    {
        throw new NotImplementedException();
    }

    public void UpdateProfile()
    {
        throw new NotImplementedException();
    }

    public List<UserResponse> GetUserDetails()
    {
        List<UserEntity> userEntity = new()
        {
            new UserEntity{
                UserName = "Ali Raza Mushtaq",
                Email = "alisaivi786@gmail.com",
                Password = "AbcTest12345",
                CreatedBy = 1
            },
            new UserEntity{
                UserName = "Mohsin Mushtaq",
                Email = "mohsinmushtaq4141@gmail.com",
                Password = "Alfa124254",
                CreatedBy = 1
            },

        };

        var res = mapper.Map<List<UserResponse>>(userEntity);
        
        return res;
    }
}
