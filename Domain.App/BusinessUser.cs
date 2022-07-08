using Contracts.Domain.Base;
using Domain.Base;

namespace Domain.App;

public class BusinessUser : DomainEntityId<Guid>, IDomainEntityId
{
    public string CompanyName { get; set; } = default!;
    public int RegistryCode { get; set; }

    public ICollection<Participation>? Participations { get; set; }
}