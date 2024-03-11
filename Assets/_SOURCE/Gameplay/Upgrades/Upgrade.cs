using Configs.Resources.Upgrades;
using Infrastructure.Utilities;

namespace Gameplay.Upgrades
{
  public class Upgrade
  {
    private UpgradeConfig _config;

    public Upgrade(UpgradeConfig config, int level)
    {
      _config = config;

      Level = new ReactiveProperty<int>(level);
    }

    public ReactiveProperty<int> Level { get; }
  }
}