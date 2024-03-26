using UnityEngine;

namespace Configs.Resources.PlayerConfigs.Scripts
{
  [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/PlayerConfig")]
  public class PlayerConfig : ScriptableObject
  {
    public float RotationSpeed;
    public float GravityScale;

    [Tooltip("Скорострельность. Выстрелов в секунду")]
    public int FireRate = 10;

    [Tooltip("Скорость полета пули")] public int BulletSpeed = 10;

    public int InitialDamage;
    public int InitialBackpackCapacity;
    public int InitialChickenCount;
    public int InitialGroupAttack;
    public int InitialMoveSpeed;
    public int InitialFireRange;
    public int InitialHealth;
  }
}