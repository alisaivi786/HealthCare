namespace HealthCare.Application.Profiles;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<UserEntity, UserResponse>()
            .ForMember(dest => dest.UserName, src => src.MapFrom(x => x.UserName))
            .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email));

        CreateMap<List<UserEntity>, List<UserResponse>>().ConvertUsing(ConvertList);
    }

    private List<UserResponse> ConvertList(List<UserEntity> source, List<UserResponse> destination, ResolutionContext context)
    {
        return source.Select(x => context.Mapper.Map<UserResponse>(x)).ToList();
    }
}


