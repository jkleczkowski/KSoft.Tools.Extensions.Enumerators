using System;
using System.Collections.Generic;
using System.Text;

namespace KSoft.Tools.Extensions
{
  public class TypeComparer : IEqualityComparer<Type>
  {
    public bool Equals(Type x, Type y)
    {
      return String.Compare(x.FullName, y.FullName, StringComparison.InvariantCulture) == 0;
    }

    public int GetHashCode(Type obj)
    {
      return obj.FullName.GetHashCode();
    }
  }
}
