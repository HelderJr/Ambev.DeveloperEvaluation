namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public sealed record SaleCreatedEvent
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int SaleId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
