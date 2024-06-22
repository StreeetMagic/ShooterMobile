using UnityEngine;

namespace Gameplay.Weapons
{
  [CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "Configs/WeaponConfig")]
  public class WeaponConfig : ScriptableObject
  {
    [Tooltip("Тип оружия")]
    public WeaponTypeId WeaponTypeId;

    [Tooltip("Тип атаки")]
    public WeaponAttackTypeId WeaponAttackTypeId;

    [Tooltip("Разлет пуль в градусах")]
    public float BulletSpreadAngle;

    [Tooltip("Скорость пули метров в сек")]
    public float BulletSpeed = 25f;

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
    
    [Tooltip("Урон одного патрона")]
    public float Damage = 10;    
    
    [Tooltip("Время на подготовку к выстрелу")]
    public float RaiseTime = .2f;
        
    [Tooltip("Длительность милишной атаки")]
    public float MeeleAttackDuration = .7f;    
    
    [Tooltip("Емкость одного магазина")]
    public int MagazineCapacity = 30;    
    
    [Tooltip("Длительность перезарядки одного магазина")]
    public float ReloadTime = 1.5f;
  }
}