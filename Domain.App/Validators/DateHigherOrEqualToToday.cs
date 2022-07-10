using System.ComponentModel.DataAnnotations;

namespace Domain.App.Validators;

public class DateHigherOrEqualToToday : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return "Ürituse kuupäev ei saa olla minevikus!";
    }

    protected override ValidationResult IsValid(object? objValue,
        ValidationContext validationContext)
    {
        var dateValue = objValue as DateTime? ?? new DateTime();


        if (dateValue.Date < DateTime.Now.Date)
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

        return ValidationResult.Success!;
    }
}