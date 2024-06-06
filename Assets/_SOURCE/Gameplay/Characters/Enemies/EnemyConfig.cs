using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/EnemyConfig")]
  public class EnemyConfig : ScriptableObject
  {
    public EnemyId Id;

    [Tooltip("Скорость движения во время патрулирования")]
    public float MoveSpeed = 5f;

    [Tooltip("Скорость бега при преследовании игрока и возвращении на место")]
    public float RunSpeed = 10f;

    [Tooltip("Время после которого включится лечение при отстутствии входящего урона")]
    public float RunTime = 1f;

    [Tooltip("Время ожидания после достижения маршрутной точки")]
    public float WaitTimeAfterMove = .1f;

    [Tooltip("Начальное здоровье")] public float InitialHealth = 100f;

    [Tooltip("Награда за убийство")] public int MoneyReward = 10;

    [Tooltip("Множитель восстановления здоровья")]
    public float HealMultiplier = 1;

    [Tooltip("Набор наград при убийстве")] public List<LootDrop> LootDrops;

    [Tooltip("Радиус стрельбы")] public float ShootRange = 10f;

    [Tooltip("Радиус агра если рядом пробежал игрок")]
    public float AggroRadius = 3f;

    [Tooltip("Скорострельность: выстрелов в секунду")]
    public int FireRate = 10;

    [Tooltip("Урон пули")] public float BulletDamage = 5;

    [Tooltip("Максимальное расстояние преследования игрока от центра спаунера")]
    public float PatrolingRadius = 20;

    [Tooltip("Награда за убийство")] public int Expirience = 100;

    [Tooltip("Радиус толкания соседних врагов (нужно для исключения стака 3д моделей)")]
    public float EnemyDetectionColliderRadius = 0.1f;

    [Tooltip("Сила отталкивания соседних врагов в радиусе действия")]
    public float ForceFromOtherEnemys = .3f;

    [Tooltip("Способность бросать гранату")]
    public bool GrenadeThrower = true;

    [Tooltip("Кулдаун бросания гранаты")]
    public float GrenadeThrowCooldown = 10f;
    
    [Tooltip("Время, после которого в неподвижную цель полетит граната")]
    public float TargetStandsOnSamePositionTime = 1f;
  }
}