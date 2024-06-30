using UnityEngine;

namespace Gameplay.Characters.Enemies.Configs
{
  [CreateAssetMenu(fileName = "EnemyVisualEffctsSetupsConfig", menuName = "ArtConfigs/EnemyVisualEffctsSetupsConfig")]
  public class EnemyVisualEffctsSetupsConfig : ScriptableObject
  {
    public EnemyVisualEffectsSetup[] VisualEffectsSetups;
  }
}