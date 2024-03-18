using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Upgrades;
using Infrastructure.Utilities;

namespace Gameplay.Characters.Players._components.PlayerStatsServices
{
  public class PlayerStatsProvider
  {
    private readonly UpgradeService _upgradeService;

    public PlayerStatsProvider(UpgradeService upgradeService)
    {
      _upgradeService = upgradeService;
    }

    public ReactiveProperty<int> BackpackCapacity { get; } = new(10);

    public int Damage => _upgradeService.GetCurrentUpgradeValue(UpgradeId.Damage);
  }
}