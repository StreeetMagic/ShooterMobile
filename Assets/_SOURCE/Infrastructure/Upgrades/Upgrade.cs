using Configs.Resources.UpgradeConfigs.Scripts;
using Infrastructure.Utilities;

namespace Infrastructure.Upgrades
{
  public class Upgrade
  {
    private readonly UpgradeConfig _config;

    public Upgrade(UpgradeConfig config, int level)
    {
      _config = config;

      Level = new ReactiveProperty<int>(level);
    }

    public ReactiveProperty<int> Level { get; }

    public bool IsMaxLevel => Level.Value == _config.Values[^1].Level;
    public bool IsPenult => Level.Value == _config.Values[^2].Level;
  }
}