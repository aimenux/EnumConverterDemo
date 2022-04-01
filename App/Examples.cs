using System.ComponentModel;

namespace App
{
    public static class Examples
    {
        public static void ConvertFromExample<T>(T converter) where T : TypeConverter
        {
            ConsoleColor.Magenta.WriteLine($"\nUsing '{converter.GetName()}'\n");

            var inputs = new object[]
            {
                "FRANCE",
                "SPAIN",
                "FR",
                "ES",
                "fr",
                "es",
                "10",
                "20",
                10
            };

            foreach (var input in inputs)
            {
                try
                {
                    ConsoleColor.Green.WriteLine($"ConvertFrom '{input}' = '{converter.ConvertFrom(input)}'");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteLine($"ConvertFrom '{input}' => Failed because '{ex.Message}'");
                }
            }
        }
    }
}