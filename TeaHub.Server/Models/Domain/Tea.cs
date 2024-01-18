namespace TeaHub.Server.Models.Domain
{
    public class Tea : BaseEntity
    {
        public string Name { get; set; } = "";
        public string? About { get; set; }
        public string? PurchasedFrom { get; set; }
        public double Score { get; set; } = 0.0;
        public Guid TypeId { get; set; }
        public Guid OriginId { get; set; }

        public Type Type { get; set; }
        public Origin Origin { get; set; }
    }
}
