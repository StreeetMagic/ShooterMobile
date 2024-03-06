using Gameplay.Characters.Enemies;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;

namespace Gameplay.RewardServices
{
  public class RewardService
  {
    private readonly IStaticDataService _staticDataService;
    private readonly DataRepository _dataRepository;

    public RewardService(IStaticDataService staticDataService, DataRepository dataRepository)
    {
      _staticDataService = staticDataService;
      _dataRepository = dataRepository;
    }

    public void OnEnemyDied(EnemyId enemyId) =>
      _dataRepository.MoneyInBackpack.Value +=
        _staticDataService
          .ForEnemy(enemyId)
          .MoneyReward;
  }
}