using Games;

namespace Infrastructure.Services.StaticDataServices
{
  public interface IStaticDataService : IService
  {
    PlayerConfig ForPlayer();
  }
}