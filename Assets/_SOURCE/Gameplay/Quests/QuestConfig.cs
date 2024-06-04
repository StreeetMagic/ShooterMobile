using System.Collections.Generic;
using Gameplay.Rewards;
using UnityEngine;

namespace Gameplay.Quests
{
  [CreateAssetMenu(menuName = "Configs/QuestConfig", fileName = "QuestConfig")]
  public class QuestConfig : ScriptableObject
  {
    public QuestId Id;
    public string Name;
    public Sprite Icon;
    public Reward Reward;

    public List<SubQuestSetup> SubQuests;
  }
}