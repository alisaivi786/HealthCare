namespace HealthCare.Application.Contract.IServices;

public interface IPatientService
{
    void RegisterPatient();
    void UpdatePatientProfile();
    void BookAppointment();
    void CancelAppointment();
    void ViewAppointment();
}
