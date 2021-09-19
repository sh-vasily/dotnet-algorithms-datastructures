using System;
using System.Collections.Generic;
using System.Linq;
using Sorting.Core.Contracts;
using Sorting.Core.Extensions;

namespace Sorting.Core.Sorters
{
    [SortingAlgorithm(SorterKind.QuickSort)]
    public class QuickSorter : AbstractSorter
    {
        protected override (T[], int countOperations) Sort<T>(T[] sourceArray, Func<T, T, bool> compare)
        {
            if (sourceArray.Length < 2)
                return (sourceArray, 0);
            
            var pivot = sourceArray.GetRandom();
            var (leftPart, rightPart) = SplitArray(sourceArray, pivot, compare);
            var (leftPartSorted, countOperationInLeftPartSorting) = Sort(leftPart, compare);
            var (rightPartSorted, countOperationInRightPartSorting) = Sort(rightPart, compare);

            var sortedArray = new List<T>();
            sortedArray.AddRange(leftPartSorted);
            sortedArray.Add(pivot);
            sortedArray.AddRange(rightPartSorted);
            
            return (sortedArray.ToArray(), countOperationInLeftPartSorting + countOperationInRightPartSorting + 1);
        }

        private (T[], T[]) SplitArray<T>(IEnumerable<T> sourceArray, T pivot, Func<T, T, bool> compare)
        {
            var sourceCollection = sourceArray.ToList();
            sourceCollection.Remove(pivot);
            
            var leftPart = sourceCollection.Where(item => compare(item, pivot));
            var rightPart = sourceCollection.Where(item => !compare(item, pivot));

            return (leftPart.ToArray(), rightPart.ToArray());
        }
    }
}