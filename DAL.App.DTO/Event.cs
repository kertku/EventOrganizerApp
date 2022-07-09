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
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
    public DateTime Date { get; set; }

    [DisplayName("Toimumiskoht")] public string Location { get; set; } = default!;

    [StringLength(1000, ErrorMessage = "{0} välja pikkus maksimaalselt {1} märki!")]
    [DisplayName("Informatsioon")]
    public string Information { get; set; } = default!;


    public ICollection<Participation>? Participations { get; set; }
}