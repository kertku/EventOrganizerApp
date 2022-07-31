using System.ComponentModel.DataAnnotations;

namespace Domain.App.Validators;

public class IdentityCodeValidator : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return $"Isikukood  {name} ei vasta Eesti isikukoodi nõuetele!";
    }

    protected override ValidationResult IsValid(object? objValue,
        ValidationContext validationContext)
    {
        var identityValue = objValue as long? ?? new long();

        long[] GetIntArray(long num)
        {
            var listOfInts = new List<long>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();
            return listOfInts.ToArray();
        }

        var identityNumbersArray = GetIntArray(identityValue);

        bool CorrectIdentity(long[] listOfNumbers)
        {
            var firstStepArray = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            var secondStepArray = new List<int> { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            long sum = 0;
            for (var i = 0; i < 10; i++) sum += listOfNumbers[i] * firstStepArray[i];

            var result = sum - sum / 11 * 11;
            if (result < 10) return result == listOfNumbers[10];

            sum = 0;


            for (var i = 0; i < 11; i++) sum += listOfNumbers[i] * secondStepArray[i];

            var resultSecond = sum - sum / 11 * 11;
            return resultSecond == listOfNumbers[10];
        }

        return CorrectIdentity(identityNumbersArray)
            ? ValidationResult.Success!
            : new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName = string.Concat(identityNumbersArray)));
    }
}