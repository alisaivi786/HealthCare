namespace HealthCare.Domain.Person;

public class UserEntity : BaseEntity
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public long? RoleId { get; set; }
}
