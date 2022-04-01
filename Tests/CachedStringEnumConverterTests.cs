using App;
using App.Converters;
using FluentAssertions;
using Xunit;

namespace Tests;

public class CachedStringEnumConverterTests
{
    [Theory]
    [InlineData("FRANCE", Country.France)]
    [InlineData("SPAIN", Country.Spain)]
    [InlineData("ITALY", Country.Italy)]
    [InlineData("PORTUGAL", Country.Portugal)]
    [InlineData("FR", Country.France)]
    [InlineData("fr", Country.France)]
    [InlineData("ES", Country.Spain)]
    [InlineData("es", Country.Spain)]
    [InlineData("IT", Country.Italy)]
    [InlineData("it", Country.Italy)]
    [InlineData("PT", Country.Portugal)]
    [InlineData("pt", Country.Portugal)]
    [InlineData("10", Country.France)]
    [InlineData("20", Country.Spain)]
    [InlineData("30", Country.Italy)]
    [InlineData("40", Country.Portugal)]
    public void ShouldConvertFromStringToEnum(string stringEnumValue, Country expectedEnumValue)
    {
        // arrange
        var convertor = new CachedStringEnumConverter<Country>();

        // act
        var result = convertor.ConvertFrom(stringEnumValue);

        // assert
        result.Should().Be(expectedEnumValue);
    }
}