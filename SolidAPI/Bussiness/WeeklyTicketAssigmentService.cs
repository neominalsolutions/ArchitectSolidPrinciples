namespace SolidAPI.Bussiness
{
  public class WeeklyTicketAssigmentService : ITicketAssigment
  {

    // haftalık toplamının 40 saat üzerinde olmaması lazım.
    public void CheckTicketAssignable(int estimatedHour, Guid employeeId, Guid ticketId)
    {
      throw new NotImplementedException();
    }
  }
}
