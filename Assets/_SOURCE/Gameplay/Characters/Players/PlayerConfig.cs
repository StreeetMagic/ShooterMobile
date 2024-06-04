using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/PlayerConfig")]
  public class PlayerConfig : ScriptableObject
  {
    public float RotationSpeed;

    public float GravityScale;

    [Tooltip("Скорострельность. Выстрелов в секунду")]
    public float FireRate = 10;

    [Tooltip("Скорость полета пули")]
    public int BulletSpeed = 10;

    public float BombDefuseDuration = 5;

    public float BombDefuseRadius = 5f;
    
    [Tooltip("Время на изготовку для стрельбы")]
    public float WeaponRaiseTime = 0.2f;
    
    [Tooltip("Начальное оружие")]
    public WeaponTypeId StartWeapon = WeaponTypeId.Knife;

    public List<StatSetup> Stats;
  }
}