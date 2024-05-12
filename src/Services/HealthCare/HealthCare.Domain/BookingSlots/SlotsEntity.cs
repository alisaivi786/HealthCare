namespace HealthCare.Domain.BookingSlots;

public class SlotsEntity
{
    public long PatientId { get; set; }
    public long DoctorId { get; set; }
    public long StatusId { get; set; }
    public DateTime StartTime { get; set; } 
    public DateTime EndTime { get; set; } 
}
