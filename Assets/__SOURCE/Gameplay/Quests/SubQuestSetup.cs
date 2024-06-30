using System;
using Gameplay.Quests.Subquests;
using Gameplay.Rewards;

namespace Gameplay.Quests
{
  [Serializable]
  public class SubQuestSetup
  {
    public SubQuestId Id;
    public int Quantity;
    public Reward Reward;
  }
}