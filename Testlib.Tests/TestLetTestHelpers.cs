namespace Testlib.Tests;

public static class TestLetTestHelpers
{
  public static List<Item> GenerateItems(int count, TestletConfig config)
  {
    var items = new List<Item>();
    for (var i = 0; i < count; i++)
    {
      items.Add(new Item(i.ToString(), i < config.PretestCount ? ItemTypeEnum.Pretest : ItemTypeEnum.Operational));
    }

    return items;
  }
}