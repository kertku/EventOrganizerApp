using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.Base;

namespace DAL.App.DTO;

public class BusinessUser : DomainEntityId<Guid>, IDomainEntityId
{
    [StringLength(64, MinimumLength = 2)] public string CompanyName { get; set; } = default!;

    [MaxLength(9999999)]
    [MinLength(1000000)]
    public int RegistryCode { get; set; }

    public int NumberOfParticipants { get; set; }

    public ICollection<Participation>? Participations { get; set; }
}