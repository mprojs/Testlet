namespace Testlib;

public class Item
{
  public string ItemId { get; set; }
  public ItemTypeEnum ItemType { get; set; }
    
  public Item(string itemId, ItemTypeEnum itemType)
  {
    ItemId = itemId;
    ItemType = itemType;
  }
}