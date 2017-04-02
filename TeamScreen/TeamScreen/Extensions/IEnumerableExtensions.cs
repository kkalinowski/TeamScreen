using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace lib12.Collections
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Determines whether the specified enumerable is empty.
        /// </summary>
        /// <param name="enumerable">The enumerable to check</param>
        /// <returns>True if enumerable is empty</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

        /// <summary>
        /// Determines whether enumerable is null or empty
        /// </summary>
        /// <param name="enumerable">The enumerable to check</param>
        /// <returns>True if enumerable is null or empty</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        /// <summary>
        /// Determines whether enumerable is not empty
        /// </summary>
        /// <param name="enumerable">The enumerable to check</param>
        /// <returns>True if enumerable is not empty</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Any();
        }

        /// <summary>
        /// Determines whether enumerable is not null and not empty
        /// </summary>
        /// <param name="enumerable">The enumerable to check</param>
        /// <returns>True if enumerable is not null and not empty</returns>
        public static bool IsNotNullAndNotEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        /// <summary>
        /// Invoke action for each element in enumerable
        /// </summary>
        /// <param name="enumeration">The enumeration of items to invoke action on</param>
        /// <param name="action">The action to invoke</param>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
                action(item);

            return enumeration;
        }

        /// <summary>
        /// If enumerable is null convert it into empty collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static IEnumerable<T> Recover<T>(this IEnumerable<T> enumerable)
        {
            return enumerable ?? Enumerable.Empty<T>();
        }
    }
}