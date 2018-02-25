using System.Collections.Generic;
using System.Linq;
using KSoft.Tools.xUnit.Logger;
using KSoft.Tools.Extensions;
using Xunit;
using Xunit.Abstractions;


namespace KSoft.Tools.Extensions.Lists.Tests
{
  public class ListAddIfNotExistsTests
  {
    protected ITestOutputHelper output;
    private TestLogger logger;

    public ListAddIfNotExistsTests(ITestOutputHelper output)
    {
      this.output = output;
      logger = new TestLogger(output);
    }

    [Fact]
    public void test_add_one_element_to_IList()
    {
      List<string> list = new List<string>()
      {
        "Element A"
      };
      list.AddIfNotExists("Element B");
      list.Count.ShouldBe(2);
      logger.Info("success");
    }

    [Fact]
    public void test_multiple_elements_to_IList()
    {
      List<string> list = new List<string>()
      {
        "Element A"
      };
      list.AddRangeIfNotExists(new[] {"Element B", "Element C"});
      list.Count.ShouldBe(3);
      list.AddRangeIfNotExists("Element A", "Element D");
      list.Count.ShouldBe(4);
      logger.Info("success");
    }
  }
}