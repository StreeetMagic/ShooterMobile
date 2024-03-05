using UnityEngine;

namespace Configs.Resources
{
  [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/PlayerConfig")]
  public class PlayerConfig : ScriptableObject
  {
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float GravityScale { get; private set; } 
  }
}