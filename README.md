# EnumConverterDemo
```
Playing with enum type converters
```

In this demo, i m experimenting the use of `EnumConverter` in order to support conversion :
>
- from string enum value to enum value
>
- from string enum member value to enum value
>
- from string integer enum value to enum value

Two implementation are provided and benchmarked :
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

**`Tools`** : vs22, net 6.0

