namespace TeaHub.Server.Models.DTO
{
    public class TeaDTO : BaseDTO
    {
        public string Name { get; set; } = "";
        public string? About { get; set; }
        public string? PurchasedFrom { get; set; }
        public double Score { get; set; } = 0.0;

        public TypeDTO Type { get; set; }
        public OriginDTO Origin { get; set; }
    }
}
