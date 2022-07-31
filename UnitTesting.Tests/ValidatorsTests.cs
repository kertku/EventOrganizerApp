namespace UnitTesting.Tests;

public class ValidatorsTests

{
    [Theory]
    [InlineData(38403150239)]
    [InlineData(37605030299)]
    [InlineData(52202090022)]
    public void EstoniaIdentityCodeValidator_isValid_Test(long value)
    {
        //Arrange
        var etIdentityValidator = new EstoniaIdentityCodeValidator();
        //Act
        var isValidIdentityCode = etIdentityValidator.CorrectIdentity(value);
        //Assert
        Assert.True(isValidIdentityCode, $"{value} is not valid identification code! ");
    }


    [Theory]
    [InlineData(38403150234)]
    [InlineData(37605030292)]
    [InlineData(52202090021)]
    public void EstoniaIdentityCodeValidator_isNotValid_Test(long value)
    {
        //Arrange
        var etIdentityValidator = new EstoniaIdentityCodeValidator();
        //Act
        var isNotValidIdentityCode = etIdentityValidator.CorrectIdentity(value);
        //Assert
        Assert.False(isNotValidIdentityCode, $"{value} is valid ");
    }
}