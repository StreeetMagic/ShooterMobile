using System.Collections.Generic;
using Stats;
using UnityEngine;
using Weapons;

namespace Characters.Players
{
  [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/PlayerConfig")]
  public class PlayerConfig : ScriptableObject
  {
    [Tooltip("Скорость поворота")]
    public float RotationSpeed;

    [Tooltip("Коэффициент гравитации")]
    public float GravityScale;

    [Tooltip("Время на разминирование бомбы")]
    public float BombDefuseDuration = 5;

    [Tooltip("Радиус обезвреживания бомбы")]
    public float BombDefuseRadius = 5f;
    
    [Tooltip("Начальные оружия. Первое оружие будет первым в списке")]
    public List<WeaponTypeId> StartWeapons;
    
    [Tooltip("Базовые характеристики игрока")]
    public List<StatSetup> Stats;
  }
}