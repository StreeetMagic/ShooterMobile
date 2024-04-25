using System;
using System.Collections.Generic;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using UnityEngine;

namespace Configs.Resources.QuestConfigs.Scripts
{
  [CreateAssetMenu(menuName = "Configs/QuestConfig", fileName = "QuestConfig")]
  public class QuestConfig : ScriptableObject
  {
    public QuestId Id;
    public string Name;
    public Sprite Icon;
    public QuestReward Reward;

    public List<SubQuestSetup> SubQuests;
  }

  [Serializable]
  public class SubQuestSetup
  {
    public SubQuestConfig Config;
    public int Quantity;
    public QuestReward Reward;
  }
}