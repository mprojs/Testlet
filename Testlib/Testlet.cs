namespace Testlib;

public class Testlet
{
  public string TestletId { get; set; }
  private readonly List<Item> items;
  private readonly TestletConfig config;
    
  public Testlet(TestletConfig config, string testletId, List<Item> items)
  {
    if (items.Count != config.TotalItemsCount)
    {
      throw new ArgumentException("Items count is not the same as in the config", nameof(items));
    }
    if (items.Count(item => item.ItemType == ItemTypeEnum.Pretest) != config.PretestCount)
    {
      throw new ArgumentException("Pretest items count is not the same as in the config", nameof(items));
    }
    if (items.Count(item => item.ItemType == ItemTypeEnum.Operational) != config.OperationalCount)
    {
      throw new ArgumentException("Operational items count is not the same as in the config", nameof(items));
    }
    
    TestletId = testletId;
    this.items = items;
    this.config = config;
  }
    
  public List<Item> Randomize()
  {
    return Randomize(new Random());
  }
  public List<Item> Randomize(Random random)
  {
    var shuffledItems = items.ToList().OrderBy(_ => random.Next()).ToList();
    
    var startPretestItems = shuffledItems.Where(item => item.ItemType == ItemTypeEnum.Pretest)
      .Take(config.StartPretestCount).ToList();
    
    return startPretestItems.Concat(shuffledItems.Except(startPretestItems)).ToList();
  }
}