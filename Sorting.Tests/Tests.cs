using System.Collections.Generic;
using FluentAssertions;
using Sorting.Core.Contracts;
using Sorting.Core.Sorters;
using Xunit;

namespace Sorting.Tests
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(SortingTestCases))]
        public void ShouldSortCorrectly(ISorter sorter, int[] sourceArray, int[] expectedArray)
        {
            //act
            var (sortedArray, _) = sorter.Execute(sourceArray, (a, b) => a > b);
            //assert
            sortedArray.Should().BeEquivalentTo(expectedArray);
        }
        
        public static IEnumerable<object[]> SortingTestCases =>
            new List<object[]>
            {
                new object[] { new BubbleSorter() as ISorter, 
                    new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10} ,
                    new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}},        
                new object[] { new BubbleSorterOptimized() as ISorter, 
                    new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10} ,
                    new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}},
                new object[] { new BubbleSorterVeryOptimized() as ISorter, 
                    new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10} ,
                    new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}},
                new object[] { new QuickSorter() as ISorter, 
                    new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10} ,
                    new[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}},
            };
    }
}