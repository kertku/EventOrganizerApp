using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.App.Validators;
using Domain.Base;

namespace DAL.App.DTO;

public class Event : DomainEntityId<Guid>
{
    public string Name { get; set; } = default!;

    [DateHigherOrEqualToToday] public DateTime Date { get; set; }

    public string Location { get; set; } = default!;

    [StringLength(5000)] public string Information { get; set; } = default!;

    public ICollection<Participation>? Participations { get; set; }
}