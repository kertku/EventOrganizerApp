using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace DAL.App.DTO;

public class PaymentType : DomainEntityId<Guid>
{
    [StringLength(32, MinimumLength = 2)] private string PaymentTypeName { get; set; } = default!;
    public ICollection<Participation>? Participations { get; set; }
}