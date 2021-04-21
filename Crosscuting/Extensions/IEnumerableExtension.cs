using System.Collections.Generic;
using System.Linq;

namespace Crosscuting.Extensions
{
    public static class IEnumerableExtension
    {
        public static bool HasValue<T>(this IEnumerable<T> value) => value != null && value.Any();
    }
}
