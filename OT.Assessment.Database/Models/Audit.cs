namespace OT.Assessment.Database.Models;

public class Audit
{
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
}