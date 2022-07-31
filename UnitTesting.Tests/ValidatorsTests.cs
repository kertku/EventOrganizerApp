using Valitators.Base.Validators;

namespace UnitTesting.Tests;

public class ValidatorsTests

{
    [Theory]
    [InlineData(38403150239)]
    [InlineData(37605030299)]
    [InlineData(52202090022)]
    public void EstoniaIdentityCodeValidatorTest(long value)
    {
        //Arrange
        var etIdentityValidator = new EstoniaIdentityCodeValidator();
        //Act
        var isValidIdentityCode = etIdentityValidator.CorrectIdentity(value);
        //Assert
        Assert.True(isValidIdentityCode, $"{value} is not valid identification code! ");
    }
}