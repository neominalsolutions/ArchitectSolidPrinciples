namespace SolidAPI.Bussiness
{

  /// <summary>
  /// aylık yada haftalık olarak bir çalışana belirli bir zaman dilimi için göre ataması yapılabilir mi kontrolü yapan domain servis.
  /// </summary>
  public interface ITicketAssigment
  {
    void CheckTicketAssignable(int estimatedHour, Guid employeeId, Guid ticketId);
  }
}
