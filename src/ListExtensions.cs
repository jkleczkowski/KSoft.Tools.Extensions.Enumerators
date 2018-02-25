using System;
using System.Collections.Generic;
using System.Linq;

namespace KSoft.Tools.Extensions
{
  public static class ListExtensions
  {
    public static void AddIfNotExists<T>(this IList<T> list, T el)
    {
      if (!list.Contains(el))
      {
        list.Add(el);
      }
    }
    
    public static void AddRangeIfNotExists<T>(this IList<T> list, IEnumerable<T> el)
    {
      foreach (var name in el) list.AddIfNotExists(name);
    }
  }
}