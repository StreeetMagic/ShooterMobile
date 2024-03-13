using Gameplay.Characters.Enemies;
using Infrastructure.DataRepositories;
using Infrastructure.StaticDataServices;

namespace Gameplay.RewardServices
{
  public class RewardService
  {
    private readonly IStaticDataService _staticDataService;
    private readonly MoneyInBankStorage _moneyInBankStorage;

    public RewardService(IStaticDataService staticDataService, MoneyInBankStorage moneyInBankStorage)
    {
      _staticDataService = staticDataService;
      _moneyInBankStorage = moneyInBankStorage;
    }

    public void OnEnemyDied(EnemyId enemyId) =>
      _moneyInBankStorage.MoneyInBank.Value +=
        _staticDataService
          .ForEnemy(enemyId)
          .MoneyReward;
  }
}