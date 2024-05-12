namespace HealthCare.Application.Contract.IServices;

public interface IAdminService
{
    void ViewAllAppointments();
    void CancelAppointment();
    void ViewDoctorDetails();
}
