using Configs.Resources.Upgrades;
using Infrastructure.Utilities;

namespace Gameplay.Upgrades
{
  public class Upgrade
  {
    private UpgradeConfig _config;

    public Upgrade(UpgradeConfig config)
    {
      _config = config;
    }

    public ReactiveProperty<int> Level { get; } = new();
  }
}