using Crm.Domain.Enums;

namespace Crm.Domain.Entities
{
    public class Deal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Stages Stage { get; set; }
        public Guid UserId { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid FunnelId { get; set; }
        public Funnel Funnel { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
