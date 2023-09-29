using ProfessonalArguments;

namespace Test
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Option a = new Option
            {
                Name = "a",
                HasValue = false,
            };
            Option b = new Option
            {
                Name = "b",
                HasValue = true
            };
            Option c = new Option
            {
                Name = "c",
                HasValue = true
            };

            List<Option> options = new List<Option>()
            {
                a, b, c
            };

            try
            {
                Arguments.Build(options);
                Console.WriteLine(b.GetValue<string>());
                Console.WriteLine(c.GetValue<string>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Done!");
            }

            Console.ReadKey(false);
        }
    }
}