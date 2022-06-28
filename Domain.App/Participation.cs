using Contracts.Domain.Base;
using Domain.App.Validators;
using Domain.Base;

namespace Domain.App;

public class Participation : DomainEntityId<Guid>, IDomainEntityId
{
    public Guid PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; } = default!; 
    
    public Guid? BusinessUserId { get; set; }
    public BusinessUser? BusinessUser { get; set; }

    public Guid? IndividualUserId { get; set; }
    public IndividualUser? IndividualUser { get; set; }

    public Guid EventId { get; set; }
    public Event? Event { get; set; }
}