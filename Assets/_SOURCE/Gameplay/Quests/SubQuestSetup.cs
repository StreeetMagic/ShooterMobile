using System;
using Gameplay.Quests.Subquests;
using Gameplay.Rewards;

namespace Gameplay.Quests
{
  [Serializable]
  public class SubQuestSetup
  {
    public SubQuestConfig Config;
    public int Quantity;
    public Reward Reward;
  }
}