using System.Collections.Generic;
using Configs.Resources.QuestConfigs.SubQuestConfigs;
using Gameplay.Currencies;
using UnityEngine;

namespace Configs.Resources.QuestConfigs
{
  [CreateAssetMenu(menuName = "Configs/QuestConfig", fileName = "QuestConfig")]
  public class QuestConfig : ScriptableObject
  {
    public QuestId Id;
    public string Name;
    public Sprite Icon;
    public QuestReward Reward;
    
    public List<SubQuestConfig> SubQuests;
  }
}