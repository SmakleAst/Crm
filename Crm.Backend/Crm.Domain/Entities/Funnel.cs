namespace Crm.Domain.Entities
{
    public class Funnel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Deal> Deals { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
