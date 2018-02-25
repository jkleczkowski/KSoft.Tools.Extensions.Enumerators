using System.Collections.Generic;
using KSoft.Tools.Extensions;


public class Example
{
  public void method()
  {
    IList<string> list = new List<string>()
    {
      "Element A"
    };
    list.AddIfNotExists("Element B");
    list.AddRangeIfNotExists(new[] {"Element A", "Element D"});
  }
}