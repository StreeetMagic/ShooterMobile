using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Configs.Resources.Enemies
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/EnemyConfig")]
  public class EnemyConfig : ScriptableObject
  {
    [field: SerializeField] public EnemyId Id { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float WaitTimeAfterMove { get; private set; }
    [field: SerializeField] public int InitialHealth { get; private set; }
    [field: SerializeField] public int MoneyReward { get; private set; } 
  }
}