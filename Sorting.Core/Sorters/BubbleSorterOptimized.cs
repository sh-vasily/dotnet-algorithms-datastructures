using System;
using Sorting.Core.Contracts;

namespace Sorting.Core.Sorters
{
    [SortingAlgorithm(SorterKind.BubbleOptimized)]
    public class BubbleSorterOptimized : AbstractSorter
    {
        protected override (T[], int countOperations) Sort<T>(T[] sourceArray, Func<T, T, bool> compare)
        {
            var arrayToSort = new T[sourceArray.Length];
            sourceArray.CopyTo(arrayToSort, 0);
            var countOperations = 0;
            for(int i = 0; i < arrayToSort.Length - 1; i++){
                for(int j = 0; j < arrayToSort.Length - 1 - i;j++){
                    if (compare(arrayToSort[j], arrayToSort[j + 1])) continue;
                    (arrayToSort[j], arrayToSort[j + 1]) = (arrayToSort[j + 1], arrayToSort[j]); 
                    countOperations++;
                }
            }
            return (arrayToSort, countOperations);
        }
    }
}