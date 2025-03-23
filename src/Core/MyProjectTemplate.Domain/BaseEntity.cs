namespace MyProjectTemplate.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool State { get; set; }
    public bool IsDeleted { get; set; }
}
