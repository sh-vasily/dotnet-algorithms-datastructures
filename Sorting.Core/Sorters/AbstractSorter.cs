using System;
using System.Diagnostics;
using Sorting.Core.Contracts;

namespace Sorting.Core.Sorters
{
    public abstract class AbstractSorter : ISorter
    {
        private readonly Stopwatch _timer = new ();
        protected abstract (T[], int countOperations) Sort<T>(T[] sourceArray, Func<T, T, bool> compare);
        public (T[], SortingMetaData) Execute<T>(T[] sourceArray, Func<T, T, bool> compare)
        {
            _timer.Reset();
            _timer.Start();
            var (sortedArray, countSortingOperations) = Sort(sourceArray, compare);
            _timer.Stop();
            return (sortedArray, new (_timer.Elapsed, countSortingOperations));
        }
    }
}