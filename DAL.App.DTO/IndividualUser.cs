using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domain.Base;
using Domain.Base;

namespace DAL.App.DTO;

public class IndividualUser : DomainEntityId<Guid>, IDomainEntityId
{
    [DisplayName("Eesnimi")]
    [StringLength(64, MinimumLength = 2)]
    public string FirstName { get; set; } = default!;

    [DisplayName("Perenimi")]
    [StringLength(64, MinimumLength = 2)]
    public string LastName { get; set; } = default!;

    public long IdentificationCode { get; set; } 
    [StringLength(1500)] public string Information { get; set; } = " ";

    public ICollection<Participation>? Participations { get; set; }

    [NotMapped] public string FullName => FirstName + " " + LastName;
}