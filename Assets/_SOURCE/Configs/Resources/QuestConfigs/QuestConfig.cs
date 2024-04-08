using System;
using Configs.Resources.UpgradeConfigs.Scripts;
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
  }

  [Serializable]
  public class QuestReward
  {
    public StatId StatId;
    public int Quantity;
  }
}