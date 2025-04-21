namespace Crm.Domain.Entities;

public class Promotion
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DiscountPercentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
}