namespace SolidAPI.Entities
{
  public class Customer
  {
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string CompanyName { get; set; }

    // uni-directional association
    public ICollection<Ticket> Tickets { get; set; }

  }
}
