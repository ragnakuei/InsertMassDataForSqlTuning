using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsertMassDataForSqlTuning.Helpers
{
    public static class CollectionHelper
    {
        public static List<List<T>> ToPaged<T>(this List<T> source, int pageSize)
        {
            var count = (source.Count / pageSize) + 1;

            var result = new List<List<T>>();

            for (int i = 0 ; i < count ; i++)
            {
                var pagedData = source.Skip(i * pageSize).Take(pageSize).ToList();
                result.Add(pagedData);
            }

            return result;
        }
    }
}
