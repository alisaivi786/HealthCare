namespace HealthCare.Application.Contract.IServices;

public interface IDoctorService
{
    void AddDoctor();
    void AddSchedule();
    void UpdateDoctorSchedule();
    void CancelAppointment();
    List<DoctorDetailsResponse> GetDoctorDetails();
}
