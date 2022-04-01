using System.ComponentModel;
using App;
using App.Converters;

Examples.ConvertFromExample(new EnumConverter(typeof(Country)));
Examples.ConvertFromExample(new StringEnumConverter<Country>());
Examples.ConvertFromExample(new CachedStringEnumConverter<Country>());

Console.WriteLine("\nPress any key to exit !");
Console.ReadKey();