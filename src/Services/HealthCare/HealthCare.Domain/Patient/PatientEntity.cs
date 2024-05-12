namespace HealthCare.Domain.Patient;

public class PatientEntity : BaseEntity
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public long? MedicalHistoryId { get; set; }
}
