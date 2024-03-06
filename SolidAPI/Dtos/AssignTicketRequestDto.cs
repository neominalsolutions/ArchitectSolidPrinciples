using System.ComponentModel.DataAnnotations;

namespace SolidAPI.Dtos
{


  public record AssignTicketRequestDto
  {
    [Range(1,40, ErrorMessage = "Min 1 Max 40 saatlik tek seferde görev ataması yapılabilir")]
    [Required(ErrorMessage = "Yaklaşık görev süresi boş geçilemez")]
    public int? EstimatedHour { get; init; }


    [Required(ErrorMessage = "Çalışan seçimi yapınız")]
    public Guid? EmployeeId { get; init; }

    [Required(ErrorMessage = "Görev seçimi yapınız")]
    public Guid? TicketId { get; init; }

    public int TicketAssignmentType { get; set; }
  }
}
