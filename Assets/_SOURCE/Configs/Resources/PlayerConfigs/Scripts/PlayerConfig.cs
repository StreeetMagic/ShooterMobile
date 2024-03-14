using UnityEngine;

namespace Configs.Resources.PlayerConfigs.Scripts
{
  [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/PlayerConfig")]
  public class PlayerConfig : ScriptableObject
  {
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float GravityScale { get; private set; }

    [Tooltip("Скорострельность. Выстрелов в секунду")]
    [field: SerializeField]
    public int FireRate { get; private set; } = 10;
    
    [Tooltip("Скорость полета пули")]
    [field: SerializeField]
    public int BulletSpeed { get; private set; } = 10;
  }
}