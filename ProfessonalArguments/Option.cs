using System;

namespace ProfessonalArguments
{
    public sealed class Option
    {
        internal string Value { get; set; } = string.Empty;
        public required bool HasValue { get; set; }
        public required string Name { get; set; } = string.Empty;
        public bool Exists { get; internal set; }


        public T GetValue<T>()
        {
            return (T)Convert.ChangeType(Value, typeof(T));
        }
    }
}
