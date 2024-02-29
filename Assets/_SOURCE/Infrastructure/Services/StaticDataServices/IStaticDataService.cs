using Configs;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;

namespace Infrastructure.Services.StaticDataServices
{
  public interface IStaticDataService : IService
  {
    PlayerConfig ForPlayer();
    EnemyConfig ForEnemy(EnemyId enemyId);
    void LoadConfigs();
  }
}