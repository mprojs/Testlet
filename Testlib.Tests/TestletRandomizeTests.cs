namespace Testlib.Tests;

public class TestletRandomizeTests
{
  private readonly TestletConfig config;

  public TestletRandomizeTests()
  {
    config = new TestletConfig();
  }

  [Test]
  public void RandomizedItemsShouldHaveTheSameCount()
  {
    var testlet = new Testlet(config, "dummyID", TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config));
    var result = testlet.Randomize();
    Assert.That(result, Has.Count.EqualTo(config.TotalItemsCount));
  }

  [Test]
  public void FirstItemsShouldHavePretestType()
  {
    var testlet = new Testlet(config, "dummyID", TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config));
    var result = testlet.Randomize();
    Assert.That(result
      .Take(config.StartPretestCount)
      .All(item => item.ItemType == ItemTypeEnum.Pretest), Is.True);
  }

  [Test]
  public void RandomizedItemsShouldBeUniq()
  {
    var testlet = new Testlet(config, "dummyID", TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config));
    var result = testlet.Randomize();
    Assert.That(new HashSet<string>(result.Select(i => i.ItemId)), Has.Count.EqualTo(config.TotalItemsCount));
  }
  
  [Test]
  public void RandomizedItemsShouldHaveExpectedOrder()
  {
    var testlet = new Testlet(config, "dummyID", TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config));
    var seedOneResult = testlet.Randomize(new Random(1));
    var expectedSeededResult = new List<int>(new[] { 1, 0, 8, 6, 5, 2, 9, 4, 3, 7 })
      .Select(item => item.ToString()).ToList();
    Assert.That(seedOneResult.Select(item => item.ItemId)
      .SequenceEqual(expectedSeededResult), Is.True);
  }
  
  [Test]
  public void RandomizedWithDifferentSeedItemsShouldHaveDifferentOrder()
  {
    var testlet = new Testlet(config, "dummyID", TestLetTestHelpers.GenerateItems(config.TotalItemsCount, config));
    var seedOneResult = testlet.Randomize(new Random(1));
    var seedTwoResult = testlet.Randomize(new Random(2));
    Assert.That(seedOneResult.Select(item => item.ItemId)
      .SequenceEqual(seedTwoResult.Select(item =>item.ItemId)), Is.Not.True);
  }
}