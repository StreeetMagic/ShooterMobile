using Infrastructure.DIC;

namespace Infrastructure.Services.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private readonly IGodFactory _godFactory;

    public StaticDataService(IGodFactory godFactory)
    {
      _godFactory = godFactory;
    }

    public void RegisterConfigs()
    {
    }
  }
}