using System;
using System.Collections.Generic;
using Kusto.Data.Common;

namespace Playground.Azure.Kusto
{
    public static class KustoExtMethods
    {
        public static List<T> QueryList<T>(this ICslQueryProvider client, string query)
        {
            List<T> ret = new List<T>();
            Type type = typeof(T);
            using (var reader = client.ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    var instance = Activator.CreateInstance(type);
                    var methods = type.GetMethods();
                    int idx = 0;
                    foreach (var method in methods)
                    {
                        if (method.Name.StartsWith("set_"))
                        {
                            method.Invoke(instance, new[] {reader.GetValue(idx++)});
                        }
                    }

                    ret.Add((T) instance);
                }
            }

            return ret;
        }
    }
}