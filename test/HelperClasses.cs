using System;
using System.Collections.Generic;
using System.Text;

namespace KSoft.Tools.Extensions.Lists.Tests
{
  public class ClassA
  {
    public string Name { get; set; }

    public override int GetHashCode()
    {
      return this.Name?.GetHashCode() ?? 0;
    }
  }

  public class ClassAComparer : IEqualityComparer<ClassA>
  {
    public bool Equals(ClassA x, ClassA y)
    {
      return String.Compare(x.Name, y.Name, StringComparison.InvariantCulture) == 0;
    }

    public int GetHashCode(ClassA obj)
    {
      return obj.Name.GetHashCode();
    }
  }


  public class ClassB:IComparable<ClassB>,IComparable
  {
    public string Name { get; set; }

    public override int GetHashCode()
    {
      return this.Name?.GetHashCode() ?? 0;
    }

    public int CompareTo(object obj)
    {
      return Math.Abs( this.GetHashCode() - obj.GetHashCode());
    }

    public int CompareTo(ClassB obj)
    {
      return String.Compare(this.Name, obj.Name, StringComparison.InvariantCulture);
    }
  }
}