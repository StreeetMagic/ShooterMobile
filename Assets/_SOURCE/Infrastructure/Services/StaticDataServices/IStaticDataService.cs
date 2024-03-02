using Configs;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;

namespace Infrastructure.Services.StaticDataServices
{
  public interface IStaticDataService
  {
    PlayerConfig ForPlayer();
    EnemyConfig ForEnemy(EnemyId enemyId);
    void LoadConfigs();
  }
}