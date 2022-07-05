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

    [DisplayName("Isikukood")]
    [RegularExpression(@"^[1-6]{1}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|[1-2][0-9]|3[0-1])[0-9]{4}$",
        ErrorMessage = "Isikukood ei vasta nõuetele!")]
    public long IdentificationCode { get; set; }

    [StringLength(1500)] public string Information { get; set; } = " ";

    public ICollection<Participation>? Participations { get; set; }

    [NotMapped] public string FullName => FirstName + " " + LastName;
}