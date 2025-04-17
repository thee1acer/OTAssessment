using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OT.Assessment.Database;
public partial class OTAssessmentContext: DbContext
{
    public OTAssessmentContext(DbContextOptions<OTAssessmentContext> options): base(options) {}

    //public virtual DbSet<ContractApprovers> ContractApprovers => Set<ContractApprovers>();
}
