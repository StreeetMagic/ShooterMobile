using Games;

namespace Infrastructure.Services.StaticDataServices
{
  public interface IStaticDataService : IService
  {
    void RegisterConfigs();
  }
}