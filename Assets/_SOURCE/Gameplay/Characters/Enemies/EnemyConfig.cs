using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/EnemyConfig")]
  public class EnemyConfig : ScriptableObject
  {
    [field: SerializeField] public EnemyId Id { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float WaitTimeAfterMove { get; private set; }
    [field: SerializeField] public int InitialHealth { get; private set; }
  }
}