namespace Testlib.Tests;

public class TestletConstructorTests
{
  private readonly TestletConfig config;

  public TestletConstructorTests()
  {
    config = new TestletConfig();
  }

  [Test]
  public void WithCorrectArgsTestletShouldBeCreated()
  {
    var items = TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config);
    var testlet = new Testlet(config, "id", items);
    Assert.That(testlet, Is.InstanceOf(typeof(Testlet)));
  }
  
  [Test]
  public void WrongItemCountShouldThrowError()
  {
    var items = TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config).Take(config.TotalItemsCount - 1).ToList();
    Assert.Throws<ArgumentException>(() =>
    {
      var wrongTestlet = new Testlet(config, "id", items);
    });
  }
  
  [Test]
  public void WrongPretestItemCountShouldThrowError()
  {
    var items = TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config);
    items.Find(item => item.ItemType == ItemTypeEnum.Pretest)!.ItemType = ItemTypeEnum.Operational;
    Assert.Throws<ArgumentException>(() =>
    {
      var wrongTestlet = new Testlet(config, "id", items);
    });
  }
  
  [Test]
  public void WrongOperationalItemCountShouldThrowError()
  {
    var items = TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config);
    items.Find(item => item.ItemType == ItemTypeEnum.Operational)!.ItemType = ItemTypeEnum.Pretest;
    Assert.Throws<ArgumentException>(() =>
    {
      var wrongTestlet = new Testlet(config, "id", items);
    });
  }
}