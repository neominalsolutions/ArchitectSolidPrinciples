namespace SolidAPI.Entities
{
  public class TicketAssigment // müşterinin açtığı ticketın çalışana atanması
  {
    public Guid TicketAssigmentId { get; init; }
    public Guid TicketId { get; init; }
    public Guid EmployeeId { get; init; }
    public int EstimatedHour { get; init; }

    public DateTime? AssignedAt { get; init; }

    public int TicketAssigmentType { get; init; }

    public TicketAssigment()
    {

    }


    public TicketAssigment(Guid ticketId, Guid employeeId, int estimatedHour, int ticketAssigmentType)
    {
      TicketAssigmentId = Guid.NewGuid();
      TicketId = ticketId;
      EmployeeId = employeeId;
      EstimatedHour = estimatedHour;
      AssignedAt = DateTime.Now;
      TicketAssigmentType = ticketAssigmentType;
    }
  }
}
