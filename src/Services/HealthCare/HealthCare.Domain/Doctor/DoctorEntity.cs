namespace HealthCare.Domain.Doctor;

public class DoctorEntity : BaseEntity
{
    public string? Name { get; set; }
    public string? Specilization { get; set; }
    public string? Phone { get; set; }
    public string? Schedule { get; set; }

}
