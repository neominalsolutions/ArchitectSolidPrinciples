namespace Solid.Domain.Entities
{
  // POCO => herhangi bir teknoloji bağımlılığı olmayan a plain old CLR object olmalıdır. 
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
