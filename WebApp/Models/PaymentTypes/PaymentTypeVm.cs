using System.Collections;
using System.ComponentModel;

namespace WebApp.Models.PaymentTypes;

public class PaymentTypeVm 
{
    public Guid Id { get; set; }
    
    [DisplayName("Maksemeetod")]
    public string PaymentTypeName { get; set; } = default!;

}