using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerProject
{
    /// <summary>
    /// Generic merge sort solution at https://swimburger.net/blog/dotnet/generic-merge-sort-in-csharp-dotnet
    /// Uses CompareTo() method as comparator.
    /// </summary>
    static class MergeSorter
    {
        /// <summary>
        /// Public merge sort acting on an IEnumerable collection.
        /// </summary>
        /// <typeparam name="T">The type of data to sort, must implement IComparable.</typeparam>
        /// <param name="list">The collection of data that will be sorted.</param>
        /// <returns>A sorted array containing the input collection's contents.</returns>

        public static IEnumerable<T> MergeSort<T>(IEnumerable<T> list) where T : IComparable
        {
            T[] items = list.ToArray();
            return InternalMergeSort(items);
        }

        /// <summary>
        /// Sorts an array of type T.
        /// </summary>
        /// <typeparam name="T">The type of data being sorted.</typeparam>
        /// <param name="items">The array to be sorted.</param>
        /// <returns>A sorted version of the input array.</returns>
        private static T[] InternalMergeSort<T>(T[] items) where T : IComparable
        {
            int listLength = items.Length;

            if (listLength == 1)
            {
                return items;
            }

            int median = listLength / 2;

            T[] left = new T[median];
            T[] right = new T[listLength - median];
            Array.Copy(items, left, left.Length);
            Array.Copy(items, median, right, 0, right.Length);

            InternalMergeSort(left);
            InternalMergeSort(right);

            return Merge(items, left, right);
        }

        /// <summary>
        /// Merges the two subarrays.
        /// </summary>
        /// <typeparam name="T">The type of data being sorted.</typeparam>
        /// <param name="items">The Array of data being sorted.</param>
        /// <param name="left">One of the arrays that will be merged.</param>
        /// <param name="right">One of the arrays that will be merged.</param>
        /// <returns>The two arrays left and right merged together in order.</returns>
        private static T[] Merge<T>(T[] items, T[] left, T[] right) where T : IComparable
        {
            int leftIndex = 0;
            int rightIndex = 0;

            int leftLength = left.Length;
            int rightLength = right.Length;
            int totalItems = leftLength + rightLength;

            for (int targetIndex = 0; targetIndex < totalItems; targetIndex++)
            {
                if (leftIndex >= leftLength)
                {
                    items[targetIndex] = right[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex];
                    leftIndex++;
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    items[targetIndex] = right[rightIndex];
                    rightIndex++;
                }
            }

            return items;
        }
    }
}
