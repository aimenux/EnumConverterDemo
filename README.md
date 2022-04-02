[![.NET](https://github.com/aimenux/EnumConverterDemo/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/EnumConverterDemo/actions/workflows/ci.yml)

# EnumConverterDemo
```
Experimenting enum type converters
```

In this demo, i m experimenting ways of conversion from enums (decorated with [EnumMember](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute)) to strings
>
The enum converter should support the following cases :
>
:pushpin: From `string enum value` To `enum value`
>
:pushpin: From `string integer enum` value To `enum value`
>
:pushpin: From `string enum member value` value To `enum value`

The built-in implementation [EnumConverter](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.enumconverter) provided by microsoft don't support the last case about [EnumMember](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.enummemberattribute)

In order to support all the cases, i m testing and benchmarking two implementations :

>
:one: `StringEnumConverter`
>
:two: `CachedStringEnumConverter`

```
|                         Method |        Mean |       Error |      StdDev |      Median |         Min |         Max | Rank |  Gen 0 | Allocated |
|------------------------------- |------------:|------------:|------------:|------------:|------------:|------------:|-----:|-------:|----------:|
| UsingCachedStringEnumConverter |    850.0 ns |    32.96 ns |    95.62 ns |    837.3 ns |    683.3 ns |  1,102.1 ns |    1 | 0.0229 |      96 B |
|       UsingStringEnumConverter | 27,620.3 ns | 1,816.07 ns | 5,151.88 ns | 25,850.7 ns | 21,417.7 ns | 43,805.8 ns |    2 | 1.0986 |   4,818 B |
```

**`Tools`** : vs22, net 6.0, xunit, fluent-assertions, benchmark-dotnet

