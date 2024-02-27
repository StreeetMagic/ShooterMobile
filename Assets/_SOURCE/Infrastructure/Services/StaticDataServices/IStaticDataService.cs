using _SOURCE.Gameplay.Characters.Enemies;
using Games;

namespace Infrastructure.Services.StaticDataServices
{
  public interface IStaticDataService : IService
  {
    PlayerConfig ForPlayer();
    EnemyConfig ForEnemy(EnemyId enemyId);
    void LoadConfigs();
  }
}