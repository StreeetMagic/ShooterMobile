using UnityEngine;

namespace Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts
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