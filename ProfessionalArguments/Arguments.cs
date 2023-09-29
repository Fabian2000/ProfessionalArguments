

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfessonalArguments
{
    public static class Arguments
    {
        private static int _buildCount = 0;

        public static string Path { get; private set; } = Environment.GetCommandLineArgs()[0];

        public static bool IsEmpty => !Environment.GetCommandLineArgs().Skip(1).Any();

        public static string[] GetAll() => Environment.GetCommandLineArgs().Skip(1).ToArray();

        private static char[] _allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ012456789".ToCharArray();

        public static void Build(List<Option> options)
        {
            Validate(options);

            _buildCount++;

            if (_buildCount > 1)
            {
                throw new Exception("Unable to build arguments more than one time");
            }

            List<string> args = GetAll().ToList();

            for (int i = 0; i < args.Count; i++)
            {
                string name = args[i];
                if (!name.StartsWith("-") && !name.StartsWith("/"))
                {
                    throw new ArgumentException($"Invalid Option {args[i]}");
                }

                name = name.Replace("-", "").Replace("/", "");

                Option option = options.Find(x => x.Name == name) ?? throw new Exception($"Invalid Option {name}");

                option.Exists = true;

                if (option.HasValue)
                {
                    if (i + 1 >= args.Count)
                    {
                        throw new ArgumentException($"Missing value for {name}");
                    }
                }

                if (option.HasValue)
                {
                    option.Value = args[i + 1];

                    if (option.Value.StartsWith("-") || option.Value.StartsWith("/"))
                    {
                        string argument = option.Value.Replace("-", "").Replace("/", "");

                        if (options.Find(x => x.Name == argument) is not null)
                        {
                            throw new ArgumentException($"Missing value for {name}");
                        }
                    }

                    i++;
                }
            }
        }

        private static void Validate(List<Option> options)
        {
            foreach (Option option in options)
            {
                foreach (char c in option.Name)
                {
                    if (!_allowedChars.Contains(c))
                    {
                        throw new Exception($"Invalid character for Option {option.Name}");
                    }
                }
            }
        }
    }
}