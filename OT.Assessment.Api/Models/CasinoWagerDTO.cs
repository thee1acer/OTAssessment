namespace OT.Assessment.Api.Models
{
    public class CasinoWagerDTO
    {
        public required Guid WagerId { get; set; }
        public required string Game { get; set; }
        public required string Provider { get; set}
        public required double Amount { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
