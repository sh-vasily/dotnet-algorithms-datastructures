using System;
using Sorting.Core.Contracts;

namespace Sorting.Core.Sorters
{
    [SortingAlgorithm(SorterKind.BubbleVeryOptimized)]
    public class BubbleSorterVeryOptimized : AbstractSorter
    {
        protected override (T[], int countOperations) Sort<T>(T[] sourceArray, Func<T, T, bool> compare)
        {
            var arrayToSort = new T[sourceArray.Length];
            sourceArray.CopyTo(arrayToSort, 0);
            var countOperations = 0;
            var sorted = false;

            while(!sorted)
            {
                sorted = true;
                for(int i =0; i < arrayToSort.Length -1 - i; i++)
                {
                    if (compare(arrayToSort[i], arrayToSort[i + 1])) continue;
                    (arrayToSort[i], arrayToSort[i + 1]) = (arrayToSort[i + 1], arrayToSort[i]);
                    countOperations++;
                    sorted = false;
                }
            }
            
            return (arrayToSort, countOperations);
        }
    }
}