namespace HealthCare.Infrastructure.Services;

public class DoctorService : ServiceFilter, IDoctorService
{
    
    public void AddDoctor()
    {
        throw new NotImplementedException();
    }

    public void AddSchedule()
    {
        throw new NotImplementedException();
    }

    public void CancelAppointment()
    {
        throw new NotImplementedException();
    }

    public void UpdateDoctorSchedule()
    {
        throw new NotImplementedException();
    }

    public List<DoctorDetailsResponse> GetDoctorDetails()
    {
        List<DoctorEntity> list = new() { 
        
            new DoctorEntity()
            {
                Name = "Ali",
            },
            new DoctorEntity()
            {
                Name = "Mohsin"
            }
        };

        var res = mapper.Map<List<DoctorDetailsResponse>>(list);

        return res;
    }

}
