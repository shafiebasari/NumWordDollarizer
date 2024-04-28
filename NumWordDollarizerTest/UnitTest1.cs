using Xunit;
using Program;
using FluentAssertions;
public class NumWordDollarizerTests
{
    [Fact]
    public void TestNumberToDollars_Zero()
    {
        // Arrange
        string input = "0";
        string expectedOutput = "Zero dollar";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be(expectedOutput);
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }

    [Fact]
    public void TestNumberToDollars_Negative()
    {
        // Arrange
        string input = "-123";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be("Negative number cannot be converted.");
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }

    [Fact]
    public void TestNumberToDollars_PositiveWithoutDecimal()
    {
        // Arrange
        string input = "123";
        string expectedOutput = "One Hundred Twenty-Three Dollars";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be(expectedOutput);
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }

    [Fact]
    public void TestNumberToDollars_PositiveWithDecimal()
    {
        // Arrange
        string input = "123.45";
        string expectedOutput = "One Hundred Twenty-Three Dollars and Forty-Five Cents";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be(expectedOutput);
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }

    [Fact]
    public void TestNumberToDollars_PositiveWithDecimalMoreThanTwoUpper()
    {
        // Arrange
        string input = "123.456789";
        string expectedOutput = "One Hundred Twenty-Three Dollars and Forty-Six Cents";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be(expectedOutput);
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }

    [Fact]
    public void TestNumberToDollars_PositiveWithDecimalMoreThanTwoLower()
    {
        // Arrange
        string input = "123.454321";
        string expectedOutput = "One Hundred Twenty-Three Dollars and Forty-Five Cents";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be(expectedOutput);
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }

    [Fact]
    public void TestNumberToDollars_AboveLimit()
    {
        // Arrange
        string input = "1000000000000000";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be("Error: The number must NOT be more than 999,999,999,999,999.99.");
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();

        // Act
        //Action act = () => NumWordDollarizer.NumberToDollars(input);

        // Assert
        //act.Should().Throw<ArgumentException>()
        //    .WithMessage("Error: The number must be between 0 and 999,999,999,999,999.");
    }

    [Fact]
    public void TestNumberToDollars_NotNunber()
    {
        // Arrange
        string input = "abc123";

        // Act
        string output = NumWordDollarizer.NumberToDollars(input);

        // Assert
        output.Should().Be("Please enter a valid number.");
        output.Should().NotBeNull();
        output.Should().BeOfType<string>();
    }
}
