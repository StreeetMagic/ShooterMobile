using UnityEngine;

namespace Gameplay.Weapons
{
  [CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "Configs/WeaponConfig")]
  public class WeaponConfig : ScriptableObject
  {
    public WeaponTypeId WeaponTypeId;

    public WeaponAttackTypeId WeaponAttackTypeId;

    [Tooltip("Разлет пуль в градусах")]
    public float BulletSpreadAngle;

    [Tooltip("Количество пуль на один выстрел")]
    public int BulletsPerShot = 1;

    [Tooltip("Количество выстрелов в бёрст")]
    public int ShotsPerBurst = 3;

    [Tooltip("Время между очередями у бёрст оружий")]
    public float TimeBetweenBursts = 0.3f;

    [Tooltip("Скорострельность выстрелов в секунду")]
    public int FireRate = 5;

    [Tooltip("Прицельная дальность стрельбы")]
    public float FireRange = 10;
  }
}