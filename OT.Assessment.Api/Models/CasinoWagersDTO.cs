namespace OT.Assessment.Api.Models
{
    public class CasinoWagersDTO
    {
        public required int Page { get; set; }
        public required int PageSize { get; set; }
        public required int Total { get; set; }
        public required int TotalPages { get; set; }

        public List<CasinoWagerDTO> Wagers { get; set; } = [];
    }
}
