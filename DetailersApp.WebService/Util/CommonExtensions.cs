using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Util
{
    public static class CommonExtensions
    {
        public static IEnumerable<T> removeDapperRowFromObject<T>(this IEnumerable<T> source)
        {
            if (source is null)
                throw new ArgumentException("the specified source is empty");

            foreach (T item in source)
            {
                var tempDict = (IDictionary<string, object>)item;
                tempDict.Remove("DapperRow");

                yield return (T)tempDict;
            }
        }
    }
}
