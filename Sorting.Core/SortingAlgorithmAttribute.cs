using System;
using Sorting.Core.Contracts;

namespace Sorting.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SortingAlgorithmAttribute : Attribute
    {
        public SortingAlgorithmAttribute(SorterKind sorterKind)
        {
            SorterKind = sorterKind;
        }

        public SorterKind SorterKind { get; }
    }
}