using System;
using System.Collections.Generic;
using System.Linq;
using KSoft.Tools.xUnit.Logger;
using KSoft.Tools.xUnit.Should;
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
    public void test_add_one_element_to_IList_with_comparer()
    {
      List<ClassA> list = new List<ClassA>()
      {
        new ClassA() {Name = "Element A"}
      };
      list.AddIfNotExists(new ClassA() {Name = "Element B"}, new ClassAComparer());
      list.AddIfNotExists(new ClassA() {Name = "Element C"}, new ClassAComparer());
      list.AddIfNotExists(new ClassA() {Name = "Element B"}, new ClassAComparer());
      list.ForEach(c => logger.Verbose($"Element: '{c.Name}'"));
      list.Count.ShouldBe(3);

      logger.Info("success");
    }

    [Fact]
    public void test_add_comparable_element_to_IList_with()
    {
      List<ClassB> list = new List<ClassB>()
      {
        new ClassB() {Name = "Element A"}
      };
      list.AddIfNotExists(new ClassB() { Name = "Element B" });
      list.AddIfNotExists(new ClassB() { Name = "Element C" });
      list.AddIfNotExists(new ClassB() { Name = "Element B" });
      list.ForEach(c => logger.Verbose($"Element: '{c.Name}'"));
      list.Count.ShouldBe(3);

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

    [Fact]
    public void test_add_one_element_of_type_to_IList()
    {
      var list = new List<Type>()
      {
        typeof(string)
      };
      list.AddIfNotExists(typeof(decimal));
      list.Count.ShouldBe(2);
      logger.Info("success");
    }
  }
}