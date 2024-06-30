using System.Collections.Generic;
using Rewards;
using UnityEngine;

namespace Quests
{
  [CreateAssetMenu(menuName = "Configs/QuestConfig", fileName = "QuestConfig")]
  public class QuestConfig : ScriptableObject
  {
    public QuestId Id;

    public Reward Reward;

    public List<SubQuestSetup> SubQuests;
  }
}