using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.App.Validators;
using Domain.Base;

namespace Domain.App;

public class Event : DomainEntityId<Guid>, IDomainEntityId
{
    public string Name { get; set; } = default!;

    [DateHigherOrEqualToToday] public DateTime Date { get; set; }

    public string Location { get; set; } = default!;

    [StringLength(5000)] 
    public string Information { get; set; } = default!;


    public ICollection<Participation>? Participations { get; set; }
}