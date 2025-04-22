namespace OT.Assessment.Api.Models
{
    public class SpenderDTO
    {
        public required Guid AccountId { get; set; }
        public required string UserName { get; set; }
        public double TotalAmountSpend { get; set; }
    }
}