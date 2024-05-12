namespace HealthCare.Application.Contract.IServices;

public interface INotificationService
{
    bool SendAppointmentReminder();
    bool NotifyAdmin();
}
