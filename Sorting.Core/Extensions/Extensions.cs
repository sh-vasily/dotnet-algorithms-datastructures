using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sorting.Core.Contracts;

namespace Sorting.Core.Extensions
{
    public static class Extensions
    {
        public static int[] NextArray(this Random random,int count, int min = Int32.MinValue, int max = Int32.MaxValue) => Enumerable
                .Repeat(0, count)
                .Select(i => random.Next(min, max))
                .ToArray();

        public static T GetRandom<T>(this T[] sourceArray)
        {
            var random = new Random();
            return sourceArray[random.Next(0, sourceArray.Length)];
        }
        
        public static string ToFormattedString(this int[] sourceArray) => sourceArray
            .Select((number, index) => index % 10 == 0 && index != 0 ? $"{number}\n" : $"{number}   ")
            .Aggregate((prev, current) => $"{prev}{current}");

        public static void AddSorters(this IServiceCollection services)
        {
            var sortersInAssemblies =
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(SortingAlgorithmAttribute), true)
                where attributes != null && attributes.Length > 0
                select  (attributes.Cast<SortingAlgorithmAttribute>().First().SorterKind, t);
            
            IDictionary<SorterKind, ISorter> sorters = sortersInAssemblies
                .ToDictionary(k => k.Item1, v => Activator.CreateInstance(v.t) as ISorter);
            
            services.AddScoped(_=>sorters);
        }
    }
}