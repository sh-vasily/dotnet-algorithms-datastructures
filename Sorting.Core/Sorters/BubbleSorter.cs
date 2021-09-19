using System;
using Sorting.Core.Contracts;

namespace Sorting.Core.Sorters
{
    [SortingAlgorithm(SorterKind.Bubble)]
    public class BubbleSorter : AbstractSorter
    {
        protected override (T[], int countOperations) Sort<T>(T[] sourceArray, Func<T, T, bool> compare)
        {
            var arrayToSort = new T[sourceArray.Length];
            sourceArray.CopyTo(arrayToSort, 0);
            var countOperations = 0;
            for(var i = 0; i < arrayToSort.Length - 1; i++){
                for(var j = 0; j < arrayToSort.Length - 1;j++)
                {
                    if (compare(arrayToSort[j], arrayToSort[j + 1])) continue;
                    (arrayToSort[j], arrayToSort[j + 1]) = (arrayToSort[j + 1], arrayToSort[j]); 
                    countOperations++;
                }
            }
            return (arrayToSort,  countOperations);
        }
    }
}