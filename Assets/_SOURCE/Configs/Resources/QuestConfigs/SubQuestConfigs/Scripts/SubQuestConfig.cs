using System;
using Gameplay.Characters.Enemies;
using Gameplay.Currencies;
using UnityEngine;

namespace Configs.Resources.QuestConfigs.SubQuestConfigs
{
  [CreateAssetMenu(menuName = "Configs/SubQuestConfig", fileName = "SubQuestConfig")] 
  public class SubQuestConfig : ScriptableObject
  {
    public SubQuestType Type;
    public Sprite Icon;
    public string Description;
  }
}