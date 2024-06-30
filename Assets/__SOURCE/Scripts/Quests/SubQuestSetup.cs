using System;
using Quests.Subquests;
using Rewards;

namespace Quests
{
  [Serializable]
  public class SubQuestSetup
  {
    public SubQuestId Id;
    public int Quantity;
    public Reward Reward;
  }
}