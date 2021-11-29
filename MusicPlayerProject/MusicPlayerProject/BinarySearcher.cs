using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerProject
{
    class BinarySearcher
    {
        /// <summary>
        /// Binary search for a collection of strings.
        /// </summary>
        /// <param name="list">The collection to search.</param>
        /// <param name="key">The search term.</param>
        /// <returns>The index in the collection of the searched item.</returns>
        public static int BinarySearch(IEnumerable<string> list, string key)
        {
            key = key.ToLower();
            int left = 0;
            int right = list.Count() - 1;

            while (left <= right)
            {
                int median = (left + right) / 2;
                string item = list.ElementAt(median);

                if (item.StartsWith(key))
                {
                    return median;
                }
                var comparison = key.CompareTo(item);
                if (comparison == 0)
                {
                    return median;
                }

                if (comparison < 0)
                {
                    right = median - 1;
                }
                else
                {
                    left = median + 1;
                }
            }

            return -1;
        }
    }
}
