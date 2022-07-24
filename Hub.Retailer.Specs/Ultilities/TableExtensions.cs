using System;
using TechTalk.SpecFlow;

namespace Hub.Retailer.Specs.Ultilities
{
    public static class TableExtensions
    {
        public static object ToModel(this Table table, object obj)
        {
            if (obj == null)
                throw new ArgumentNullException($"Object should not be null");

            foreach (var row in table.Rows)
            {
                obj.GetType().GetProperty(row[0]).SetValue(obj, row[1]);
            }
            return obj;
        }
    }
}
