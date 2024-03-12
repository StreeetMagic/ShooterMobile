using Configs.Resources.Upgrades;
using Gameplay.Upgrades;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class DataRepository : IProgressWriter
  {
    private readonly UpgradeService _upgradeService;
    private readonly IStaticDataService _staticDataService;

    public DataRepository(UpgradeService upgradeService, IStaticDataService staticDataService)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
    }

    public ReactiveProperty<int> MoneyInBank { get; } = new();
    public ReactiveProperty<int> MoneyInBackpack { get; } = new();

    public ReactiveProperty<int> EggsInBank { get; } = new();
    public ReactiveProperty<int> EggsInBackpack { get; } = new();

    public ReactiveProperty<int> Expierience { get; } = new();

    public float BulletDamage =>
      _staticDataService
        .ForUpgradeConfig(UpgradeId.Damage)
        .Values[LevelValue]
        .Value;

    private int LevelValue => 
      _upgradeService
        .GetUpgrade(UpgradeId.Damage)
        .Level
        .Value;

    public void ReadProgress(Progress progress)
    {
      MoneyInBank.Value = progress.MoneyInBank;
      MoneyInBackpack.Value = progress.MoneyInBackpack;

      EggsInBank.Value = progress.EggsInBank;
      EggsInBackpack.Value = progress.EggsInBackpack;

      Expierience.Value = progress.Expierience;
    }

    public void WriteProgress(Progress progress)
    {
      progress.MoneyInBank = MoneyInBank.Value;
      progress.MoneyInBackpack = MoneyInBackpack.Value;

      progress.EggsInBank = EggsInBank.Value;
      progress.EggsInBackpack = EggsInBackpack.Value;

      progress.Expierience = Expierience.Value;
    }
  }
}