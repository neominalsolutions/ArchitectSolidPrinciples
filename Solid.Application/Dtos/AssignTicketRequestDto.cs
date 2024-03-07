using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Solid.Application.Dtos
{


  public record AssignTicketRequestDto
  {
    [Range(1,40, ErrorMessage = "Min 1 Max 40 saatlik tek seferde görev ataması yapılabilir")]
    [Required(ErrorMessage = "Yaklaşık görev süresi boş geçilemez")]
    [DefaultValue(40)]
    public int? EstimatedHour { get; init; }


    [Required(ErrorMessage = "Çalışan seçimi yapınız")]
    [DefaultValue("210eddb8-fb47-4562-9613-63310ce32799")]
    public Guid? EmployeeId { get; init; }

    [Required(ErrorMessage = "Görev seçimi yapınız")]
    [DefaultValue("e85b1921-8cd3-4d0b-bb64-c61922f0fde9")]
    public Guid? TicketId { get; init; }

    [DefaultValue(100)]
    public int TicketAssignmentType { get; set; }
  }
}
