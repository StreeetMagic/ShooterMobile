using Infrastructure.Services.ZenjectFactory;

namespace Infrastructure.Services.StaticDataServices
{
  public class StaticDataService : IStaticDataService
  {
    private readonly IZenjectFactory _godFactory;

    public StaticDataService(IZenjectFactory godFactory)
    {
      _godFactory = godFactory;
    }

    public void RegisterConfigs()
    {
    }
  }
}