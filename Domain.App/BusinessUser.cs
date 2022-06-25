using System.ComponentModel.DataAnnotations;

namespace Domain.App;

public class BusinessUser
{
    [MaxLength(64), MinLength(2)]
    public string CompanyName { get; set; } = default!;
    [MaxLength(9999999), MinLength(1000000)]
    public int RegistryCode { get; set; }
    public int NumberOfParticipants { get; set; }

    public ICollection<Participation>? Participations { get; set; }
}