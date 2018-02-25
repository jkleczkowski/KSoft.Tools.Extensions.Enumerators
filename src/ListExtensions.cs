using System;
using System.Collections.Generic;
using System.Linq;

namespace KSoft.Tools.Extensions
{
  public static class ListExtensions
  {
    public static void AddIfNotExists<T>(this IList<T> list, T el) 
    {
      var comparer = new DefaultComaprer<T>();
      list.AddIfNotExists(el, comparer);
    }

    public static void AddIfNotExists<T>(this IList<T> list, T el, IEqualityComparer<T> comparer)
    {
      if (!list.Contains(el, comparer))
      {
        list.Add(el);
      }
    }

    public static void AddRangeIfNotExists<T>(this IList<T> list, IEnumerable<T> el)
    {
      foreach (var name in el) list.AddIfNotExists(name);
    }

    public static void AddRangeIfNotExists<T>(this IList<T> list, IEnumerable<T> el, IEqualityComparer<T> comparer)
    {
      foreach (var name in el) list.AddIfNotExists(name, comparer);
    }

    public static void AddRangeIfNotExists<T>(this IList<T> list, params T[] elements)
    {
      foreach (var name in elements) list.AddIfNotExists(name);
    }


    public static void AddRangeIfNotExists<T>(this IList<T> list, IEqualityComparer<T> comparer, params T[] elements)
    {
      foreach (var name in elements) list.AddIfNotExists(name, comparer);
    }
  }

  internal class DefaultComaprer<T> : IEqualityComparer<T>
  {
    public bool Equals(T x, T y)
    {
      return x.GetHashCode() == y.GetHashCode();
    }

    public int GetHashCode(T obj)
    {
      return obj.GetHashCode();
    }
  }
}