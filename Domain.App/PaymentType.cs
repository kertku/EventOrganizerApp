using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.Base;

namespace Domain.App;

public class PaymentType : DomainEntityId<Guid>, IDomainEntityId
{
    [StringLength(32, MinimumLength = 2)] 
    private string PaymentTypeName { get; set; } = default!;
    public ICollection<Participation>? Participations { get; set; }
}