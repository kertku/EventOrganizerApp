using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.App.Validators;
using Domain.Base;

namespace DAL.App.DTO;

public class Event : DomainEntityId<Guid>, IDomainEntityId
{
    [DisplayName("Ürituse nimi")] public string Name { get; set; } = default!;

    [DateHigherOrEqualToToday]
    [DisplayName("Toimumisaeg")]
    public DateTime Date { get; set; }

    [DisplayName("Toimumiskoht")] public string Location { get; set; } = default!;

    [StringLength(5000)] public string Information { get; set; } = default!;


    public ICollection<Participation>? Participations { get; set; }
}