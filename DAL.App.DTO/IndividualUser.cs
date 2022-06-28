using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domain.Base;
using Domain.Base;

namespace DAL.App.DTO;

public class IndividualUser : DomainEntityId<Guid>, IDomainEntityId
{
    [StringLength(64, MinimumLength = 2)] public string FirstName { get; set; } = default!;
    [StringLength(64, MinimumLength = 2)] public string LastName { get; set; } = default!;
    public long IdentificationCode { get; set; } = default!;
    [StringLength(1500)] public string Information { get; set; } = default!;

    public ICollection<Participation>? Participations { get; set; }

    [NotMapped] public string FullName => FirstName + " " + LastName;
}