using Contracts.Domain.Base;
using Domain.Base;

namespace Domain.App;

public class Event : DomainEntityId<Guid>, IDomainEntityId
{
    public string Name { get; set; } = default!;

    public DateTime Date { get; set; }

    public string Location { get; set; } = default!;

    public string Information { get; set; } = default!;


    public ICollection<Participation>? Participations { get; set; }
}