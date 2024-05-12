namespace HealthCare.Domain.Abstract;

public class BaseEntity
{
    public long Id { get; set; }
    public Guid? RowId { get; set; } = Guid.NewGuid();
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public long? CreatedBy { get; set; }
    public DateTime UpdatedTime { get; set; } = DateTime.UtcNow;
    public long? UpdatedBy { get; set;}
    public bool IsActive { get; set; } = true;
   

}
