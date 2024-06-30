using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Quests.Subquests
{
  [CreateAssetMenu(menuName = "ArtConfigs/SubQuestContentConfig", fileName = "SubQuestContentConfig")]
  public class SubQuestContentConfig : ScriptableObject
  {
    public List<SubQuestContentSetup> Setups; 
  }
}