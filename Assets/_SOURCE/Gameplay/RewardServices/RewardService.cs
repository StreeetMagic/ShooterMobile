using Gameplay.Characters.Enemies;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticDataServices;

namespace Gameplay.RewardServices
{
  public class RewardService
  {
    private readonly PersistentProgressService _progressService;
    private readonly IStaticDataService _staticDataService;

    public RewardService(PersistentProgressService progressService, IStaticDataService staticDataService)
    {
      _progressService = progressService;
      _staticDataService = staticDataService;
    }

    public void OnEnemyDied(EnemyId enemyId) =>
      _progressService.MoneyInBackpack.Value +=
        _staticDataService
          .ForEnemy(enemyId)
          .MoneyReward;
  }
}