using Sorting.Core.Sorters;
using Xunit;

namespace Sorting.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var sorter = new QuickSorter();
            var arrayToSort = new [] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            //act
            sorter.Execute(arrayToSort, (a, b) => a < b);
            //assert
        }
    }
}