namespace OT.Assessment.Api.Models;

public class AuditDTO
{
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
}