using System;
using Gameplay.Stats;

namespace Gameplay.Upgrades
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