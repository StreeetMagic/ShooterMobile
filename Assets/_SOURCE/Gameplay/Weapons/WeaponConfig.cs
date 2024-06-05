using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "Configs/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
  public WeaponTypeId WeaponTypeId;

  public WeaponAttackTypeId WeaponAttackTypeId;

  public float BulletSpreadAngle;

  [Tooltip("Количество пуль на один выстрел")]
  public int BulletsPerShot;
  
  [Tooltip("Количество выстрелов в бёрст")]
  public int ShotsPerBurst;

  [Tooltip("Время между очередями у бёрст оружий")]
  public float TimeBetweenBursts;

  [Tooltip("Скорострельность выстрелов в секунду")]
  public int FireRate;
}