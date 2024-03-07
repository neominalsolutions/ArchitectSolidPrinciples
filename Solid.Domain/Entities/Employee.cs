namespace Solid.Domain.Entities
{
  public class Employee // Atanacak olan görev bilgisini yöneten sınıf çalışan sınıfı.
  {
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string SurName { get; private set; }
    public string? Department { get; set; } // Optional

    // çalışana atanan görevler

    private List<TicketAssigment> ticketAssigments = new List<TicketAssigment>();
    public IReadOnlyList<TicketAssigment> Tickets => ticketAssigments;

    public Employee()
    {

    }

    public Employee(string name, string surname)
    {
      Id = Guid.NewGuid();
      Name = name.Trim();
      SurName = surname.Trim().ToUpper();
    }

    // çalışana bir atama olduğu için çalışan üzerinden bir method ile süreci işletiyoruz.
    // çalışan sınıfına bu davranış bu yetkiyi veriyoruz.
    // Buna clean code Information Expert ismi verilir.
    public void AddTicket(Guid TicketId, int estimatedHour, int ticketAssigmentType)
    {
      ticketAssigments.Add(new TicketAssigment(employeeId: new Guid("210eddb8-fb47-4562-9613-63310ce32799"), ticketId:TicketId,estimatedHour:estimatedHour, ticketAssigmentType: ticketAssigmentType));
    }


  }
}
