using System;

namespace Sorting.Core.Contracts
{
    public interface ISorter
    {
        (T[], SortingMetaData) Execute<T>(T[] sourceArray, Func<T,T,bool> compare);
    }
}