# KSoft.Tools.Extensions.Lists

1. Add package do Your project

```powershell
Install-Package KSoft.Tools.Extensions.Lists
```

2. Use:

```csharp
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
    //or 
     list.AddRangeIfNotExists("Element A", "Element D");
  }
}
```