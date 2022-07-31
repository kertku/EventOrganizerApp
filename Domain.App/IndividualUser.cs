using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domain.Base;
using Domain.Base;

namespace Domain.App;

public class IndividualUser : DomainEntityId<Guid>, IDomainEntityId
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public long IdentificationCode { get; set; }

    public string? Information { get; set; }

    public ICollection<Participation>? Participations { get; set; }

    [NotMapped] public string FullName => FirstName + " " + LastName;
}