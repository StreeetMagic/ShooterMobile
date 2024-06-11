using System.Collections.Generic;
using Gameplay.Grenades;
using Gameplay.Loots;
using UnityEngine;

namespace Gameplay.Characters.Enemies
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
    
    [Tooltip("Максимальное расстояние преследования игрока от центра спаунера")]
    public float PatrolingRadius = 20;

    [Tooltip("Время после которого включится лечение при отстутствии входящего урона")]
    public float HealingDelay = 1f;

    [Tooltip("Время ожидания после достижения маршрутной точки")]
    public float WaitTimeAfterMove = .1f;

    [Tooltip("Начальное здоровье")] 
    public float InitialHealth = 100f;

    [Tooltip("Награда за убийство")] 
    public int MoneyReward = 10;

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

    [Tooltip("Радиус стрельбы")] 
    public float ShootRange = 10f;

    [Tooltip("Скорострельность: выстрелов в секунду")]
    public int FireRate = 10;

    [Tooltip("Урон пули")] 
    public float BulletDamage = 5;
    
    [Tooltip("Емкость магазина")]
    public int MagazineCapacity = 10;
    
    [Tooltip("Время перезарядки")]
    public float MagazineReloadTime = 2f;
    
    [Tooltip("Пуль за один выстрел")]
    public int BulletsPerShot = 1;    
    
    [Tooltip("Угол разброса пуль")]
    public float BulletSpreadAngle = 1;

    /************************/

    [Tooltip("Способность бросать гранату")] [Space]
    public bool GrenadeThrower = true;

    [Tooltip("ID гранаты")]
    public GrenadeTypeId GrenadeTypeId = GrenadeTypeId.Frag1;

    [Tooltip("Кулдаун бросания гранаты")]
    public float GrenadeThrowCooldown = 10f;
    
    [Tooltip("Случайная задержка перед броском гранаты. От нуля и до текущего значения")]
    public float GrenadeThrowRandomDelay = 1f;
    
    [Tooltip("Время, после которого в неподвижную цель полетит граната")]
    public float TargetStandsOnSamePositionTime = 1f;
    
    [Tooltip("Доступно гранат")]
    public int MaxGrenadesCount = 3;

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