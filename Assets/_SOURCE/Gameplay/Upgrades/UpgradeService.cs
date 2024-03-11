using System;
using System.Collections.Generic;
using Configs.Resources.Upgrades;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;

namespace Gameplay.Upgrades
{
  public class UpgradeService : IProgressWriter
  {
    private readonly PersistentProgressService _progressService;
    private readonly IStaticDataService _staticDataService;
    private readonly SaveLoadService _saveLoadService;

    private Dictionary<UpgradeId, Upgrade> _upgrades;

    public UpgradeService(IStaticDataService staticDataService,
      PersistentProgressService progressService,
      SaveLoadService saveLoadService)
    {
      _staticDataService = staticDataService;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }

    public event Action Changed;

    public void BuyUpgrade(UpgradeId upgradeId)
    {
      if (_upgrades.TryGetValue(upgradeId, out Upgrade upgrade) == false)
        return;

      upgrade.Level.Value++;
      Changed?.Invoke();
    }

    public Upgrade ForUpgrade(UpgradeId upgradeId) =>
      _upgrades.TryGetValue(upgradeId, out Upgrade upgrade) 
        ? upgrade 
        : null;

    public void ReadProgress(Progress progress)
    {
      Dictionary<UpgradeId, UpgradeConfig> upgrades = _staticDataService.ForUpgrades();

      List<UpgradeId> keys = new List<UpgradeId>(upgrades.Keys);

      foreach (UpgradeId upgradeId in upgrades.Keys)
        keys.Add(upgradeId);

      _upgrades = new Dictionary<UpgradeId, Upgrade>();

      for (int i = 0; i < upgrades.Count; i++)
        _upgrades.Add(keys[i], new Upgrade(upgrades[keys[i]], progress.Upgrades[i].Level));
    }

    public void WriteProgress(Progress progress)
    {
    }
  }
}