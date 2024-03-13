using System;
using Configs.Resources.UpgradeConfigs.Scripts;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class UpgradeProgress
  {
    public UpgradeId Id;
    public int Level;

    public UpgradeProgress(UpgradeId id, int level)
    {
      Id = id;
      Level = level;
    }
  }
}