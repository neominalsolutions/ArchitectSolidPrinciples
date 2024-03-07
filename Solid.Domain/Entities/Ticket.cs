namespace Solid.Domain.Entities
{
  public class Ticket // Müşterinin açtığı ticket
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CustomerId { get; set; }

    public List<TicketAssigment> TicketAssigments { get; set; }

  }
}
