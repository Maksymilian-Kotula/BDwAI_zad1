using System;
using System.Collections.Generic;
using System.Linq;

namespace MojProgram
{
    public static class MetodyRozszerzajace
    {
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return !source.Any();
        }

        public static double Mean(this IEnumerable<int> source)
        {
            if (source == null || !source.Any()) return 0;
            return source.Average();
        }

        public static float Mean(this IEnumerable<float> source)
        {
            if (source == null || !source.Any()) return 0f;
            return source.Average();
        }

        public static double MeanLength(this IEnumerable<string> source)
        {
            if (source == null || !source.Any()) return 0;
            return source.Average(s => s.Length);
        }
    }
}