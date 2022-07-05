using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.Base;

namespace DAL.App.DTO;

public class PaymentType : DomainEntityId<Guid>, IDomainEntityId
{
    [StringLength(32, MinimumLength = 2)]
    [DisplayName("Makseviis")]
    public string PaymentTypeName { get; set; } = default!;

    public ICollection<Participation>? Participations { get; set; }
}