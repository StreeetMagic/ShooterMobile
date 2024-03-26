using System;
using Configs.Resources.UpgradeConfigs.Scripts;

namespace Infrastructure.PersistentProgresses
{
  [Serializable]
  public class UpgradeProgress
  {
    public StatId Id;
    public int Level;

    public UpgradeProgress(StatId id, int level)
    {
      Id = id;
      Level = level;
    }
  }
}