using UnityEngine;

namespace Gameplay.Common
{
  [CreateAssetMenu(fileName = "CommonGameplayConfig", menuName = "Configs/CommonGameplayConfig")]
  public class CommonGameplayConfig : ScriptableObject
  {
    [Tooltip("Максимальное время жизни пули")]
    public float ProjectileLifeTime = 2f;
  }
}