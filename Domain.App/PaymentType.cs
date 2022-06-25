using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App.Validators;

public class PaymentType:DomainEntityId<Guid>
{
    [MaxLength(32)]
    private string PaymentTypeName { get; set; } = default!;
    public ICollection<Participation>? Participations { get; set; }
    
}