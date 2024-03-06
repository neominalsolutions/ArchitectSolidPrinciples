namespace SolidAPI.Entities
{
  public class Ticket // Müşterinin açtığı ticket
  {
    public Guid TicketId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CustomerId { get; set; }

    // Ticket giren müşteri
    public List<TicketAssigment> TicketAssigments { get; set; }

  }
}
