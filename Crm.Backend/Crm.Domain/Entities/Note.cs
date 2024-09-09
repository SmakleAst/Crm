namespace Crm.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
