using App;
using App.Converters;
using BenchmarkDotNet.Attributes;

namespace Benchs;

[Config(typeof(BenchConfig))]
public class EnumConverterBench
{
    private static readonly StringEnumConverter<Country> StringEnumConverter = new StringEnumConverter<Country>();

    private static readonly CachedStringEnumConverter<Country> CachedStringEnumConverter = new CachedStringEnumConverter<Country>();

    private static readonly string[] StringEnumValues = new[]
    {
        "FRANCE",
        "SPAIN",
        "FR",
        "ES",
        "10",
        "20"
    };

    [Benchmark]
    [BenchmarkCategory(nameof(BenchCategory.StringEnumConverter))]
    public void UsingStringEnumConverter()
    {
        foreach (var stringEnumValue in StringEnumValues)
        {
            StringEnumConverter.ConvertFrom(stringEnumValue);
        }
    }

    [Benchmark]
    [BenchmarkCategory(nameof(BenchCategory.StringEnumConverter))]
    public void UsingCachedStringEnumConverter()
    {
        foreach (var stringEnumValue in StringEnumValues)
        {
            CachedStringEnumConverter.ConvertFrom(stringEnumValue);
        }
    }
}