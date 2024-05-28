using UnityEngine;

namespace Gameplay.Quests.Subquests
{
  [CreateAssetMenu(menuName = "Configs/SubQuestConfig", fileName = "SubQuestConfig")] 
  public class SubQuestConfig : ScriptableObject
  {
    public SubQuestType Type;
    public Sprite Icon;
    public string Name;
    public string Description;
  }
}