namespace Testlib;

public class TestletConfig
{
  public int TotalItemsCount { get; set; }
  public int PretestCount { get; set; }
  public int OperationalCount { get; set; }
  public int StartPretestCount { get; set; }
  
  private const int DefaultPretestCount = 4;
  private const int DefaultOperationalCount = 6;
  private const int DefaultStartPretestCount = 2;
    
  public TestletConfig(int pretestCount = DefaultPretestCount, int operationalCount = DefaultOperationalCount, 
    int startPretestCount = DefaultStartPretestCount)
  {
    PretestCount = pretestCount;
    OperationalCount = operationalCount;
    StartPretestCount = startPretestCount;
    TotalItemsCount = operationalCount + pretestCount;
  }
}