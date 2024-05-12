namespace HealthCare.Application.Profiles;

public class DotorProfile : Profile
{
    public DotorProfile()
    {
        CreateMap<DoctorEntity, DoctorDetailsResponse>()
            .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name));
       
        CreateMap<List<DoctorEntity>, List<DoctorDetailsResponse>>().ConvertUsing(ConvertList);
    }

    private List<DoctorDetailsResponse> ConvertList(List<DoctorEntity> source, List<DoctorDetailsResponse> destination, ResolutionContext context)
    {
        return source.Select(x => context.Mapper.Map<DoctorDetailsResponse>(x)).ToList();
    }
}
