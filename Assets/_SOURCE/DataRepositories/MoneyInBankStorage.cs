using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Upgrades;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;

namespace Infrastructure.DataRepositories
{
  public class MoneyInBankStorage : IProgressWriter
  {
    private readonly UpgradeService _upgradeService;
    private readonly IStaticDataService _staticDataService;

    public MoneyInBankStorage(UpgradeService upgradeService, IStaticDataService staticDataService)
    {
      _upgradeService = upgradeService;
      _staticDataService = staticDataService;
    }

    public ReactiveProperty<int> MoneyInBank { get; } = new();

    public float BulletDamage =>
      _staticDataService
        .ForUpgradeConfig(UpgradeId.Damage)
        .Values[DamageUpgradeLevel]
        .Value;
    
    public float MoveSpeed =>
      _staticDataService
        .ForUpgradeConfig(UpgradeId.MoveSpeed)
        .Values[SpeedUpgradeLevel]
        .Value;

    private int SpeedUpgradeLevel =>
      _upgradeService
        .GetUpgrade(UpgradeId.MoveSpeed)
        .Level
        .Value;

    private int DamageUpgradeLevel => 
      _upgradeService
        .GetUpgrade(UpgradeId.Damage)
        .Level
        .Value;

    public void ReadProgress(Progress progress)
    {
      MoneyInBank.Value = progress.MoneyInBank;
    }

    public void WriteProgress(Progress progress)
    {
      progress.MoneyInBank = MoneyInBank.Value;
    }
  }
}