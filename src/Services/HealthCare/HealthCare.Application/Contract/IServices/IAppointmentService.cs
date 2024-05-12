namespace HealthCare.Application.Contract.IServices;

public interface IAppointmentService
{
    void BookAppointment();
    void CancelAppointment();
    void RescheduleAppointment();
}
