namespace HealthCare.Domain.Appointments;

public class AppointmentEntity : BaseEntity
{
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public DateTime? DateTime { get; set; }
    public long? StatusId { get; set; }
}
