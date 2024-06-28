using System.Collections.Generic;
using Gameplay.Grenades;
using Gameplay.Loots;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Configs
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/EnemyConfig")]
  public class EnemyConfig : ScriptableObject
  {
    [Tooltip("Идентификатор")]
    public EnemyTypeId Id;

    [Tooltip("Скорость движения во время патрулирования")]
    public float MoveSpeed = 5f;

    [Tooltip("Скорость бега при преследовании игрока и возвращении на место")]
    public float RunSpeed = 10f;

    [Tooltip("Время простоя в состоянии покоя")]
    public float IdleDuration = .5f;

    [Tooltip("Радиус запроса помощи от противников из других спаунеров. На арене всегда максимальный")]
    public float AssistCallRadius = 10f;
    
    [Tooltip("Максимальное расстояние преследования игрока от центра спаунера")]
    public float PatrolingRadius = 20;

    [Tooltip("Длительность ошеломления после получения урона и перехода в состояние атаки")]
    public float AlertDuration = .2f;

    [Tooltip("Начальное здоровье")] 
    public float InitialHealth = 100f;

    [Tooltip("Множитель восстановления здоровья")]
    public float HealMultiplier = 1;

    [Tooltip("Набор наград при убийстве")] 
    public List<LootDrop> LootDrops;
    
    [Tooltip("Награда за убийство")] 
    public int Expirience = 100;
    
    /************************/

    [Tooltip("Радиус агра если рядом пробежал игрок")]
    public float AggroRadius = 3f;
    
    /************************/

    [Tooltip("Стреляющий")] [Space]
    public bool IsShooter;

    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Радиус стрельбы")] 
    public float ShootRange = 10f;

    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Скорострельность: выстрелов в секунду")]
    public int FireRate = 10;

    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Урон пули")] 
    public float BulletDamage = 5;
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Скорость полета пули метров в сек")] 
    public float BulletSpeed = 25;
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Емкость магазина")]
    public int MagazineCapacity = 10;
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Время перезарядки")]
    public float MagazineReloadTime = 2f;
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Пуль за один выстрел")]
    public int BulletsPerShot = 1;    
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Угол разброса пуль")]
    public float BulletSpreadAngle = 1;    
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Длительность подъема оружия")]
    public float WeaponRisingTime = .2f;
    
    [FoldoutGroup(nameof(IsShooter))]
    [ShowIf(nameof(IsShooter))]
    [Tooltip("Длительность опускания оружия")]
    public float WeaponLoweringTime = .2f;

    /************************/

    [Tooltip("Способность бросать гранату")] [Space]
    public bool IsGrenadeThrower = true;

    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("ID гранаты")]
    public GrenadeTypeId GrenadeTypeId = GrenadeTypeId.Frag;

    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("Кулдаун бросания гранаты")]
    public float GrenadeThrowCooldown = 10f;
    
    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("Случайная задержка перед броском гранаты. От нуля и до текущего значения")]
    public float GrenadeThrowRandomDelay = 1f;
    
    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("Длительность броска гранаты")]
    public float GrenadeThrowDuration = 1f;
    
    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("Время, после которого в неподвижную цель полетит граната")]
    public float TargetStandsOnSamePositionTime = 1f;
    
    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("Доступно гранат")]
    public int MaxGrenadesCount = 3;

    [FoldoutGroup(nameof(IsGrenadeThrower))]
    [ShowIf(nameof(IsGrenadeThrower))]
    [Tooltip("Радиус броска гранат")]
    public float GrenadeThrowRange = 5f;
    
    /************************/

    [Tooltip("Радиус милишной атаки")] [Space]
    public float MeleeRange = 2;
    
    [Tooltip("Время милишной атаки")]
    public float MeeleAttackDuration = .2f; 
    
    [Tooltip("Урон милишной атаки")]
    public float MeeleAttackDamage = 1000;
  }
}