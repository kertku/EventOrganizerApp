using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.Base;

namespace DAL.App.DTO;

public class BusinessUser : DomainEntityId<Guid>, IDomainEntityId
{
    [StringLength(64, MinimumLength = 2)]
    [DisplayName("Ettevõtte nimetus")]

    public string CompanyName { get; set; } = default!;

    [Range(10000000, 99999999,
        ErrorMessage = "{0} peab olema kaheksa kohaline number.")]
    [DisplayName("Registrikood ")]
    public int RegistryCode { get; set; }

    [DisplayName("Osalejate arv")] public int NumberOfParticipants { get; set; }

    [DisplayName("Osalejad")] public ICollection<Participation>? Participations { get; set; }
}