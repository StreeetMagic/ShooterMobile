using UnityEngine;

namespace Gameplay.Characters.Enemies.Configs
{
  [CreateAssetMenu(fileName = "EnemyTypeVisualEffectsConfig", menuName = "ArtConfigs/EnemyTypeVisualEffectsConfig")]
  public class EnemyTypeVisualEffectsConfig : ScriptableObject
  {
    public EnemyTypeVisualEffectsSetup[] VisualEffectsSetups;
  }
}