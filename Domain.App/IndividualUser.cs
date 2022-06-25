using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App;

public class IndividualUser : DomainEntityId<Guid>
{
    [MaxLength(64), MinLength(2)]
    public string FirstName { get; set; } = default!;
    [MaxLength(64), MinLength(2)]
    public string LastName { get; set; } = default!;
    public long IdentificationCode { get; set; } = default!;
    [MaxLength(1500), MinLength(2)]
    public string Information { get; set; } = default!;

    public ICollection<Participation>? Participations { get; set; }
}