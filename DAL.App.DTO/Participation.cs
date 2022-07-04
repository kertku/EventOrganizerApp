using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Contracts.Domain.Base;
using Domain.Base;

namespace DAL.App.DTO;

public class Participation : DomainEntityId<Guid>, IDomainEntityId
{
    [DisplayName("Informatsioon")]
    [StringLength(5000)]
    public string? Information { get; set; }

    [DisplayName("Maksetüüp")] public Guid PaymentTypeId { get; set; }

    public PaymentType PaymentType { get; set; } = default!;

    public Guid? BusinessUserId { get; set; }
    public BusinessUser? BusinessUser { get; set; }

    public Guid? IndividualUserId { get; set; }
    public IndividualUser? IndividualUser { get; set; }

    public Guid EventId { get; set; }
    public Event? Event { get; set; }
}