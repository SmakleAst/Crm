namespace Crm.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
