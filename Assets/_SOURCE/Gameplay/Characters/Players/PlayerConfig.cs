using System;
using System.Collections.Generic;
using Gameplay.Stats;
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

    [Tooltip("Скорость полета пули")] public int BulletSpeed = 10;

    public List<StatValuePair> Stats;

    [Serializable]
    public class StatValuePair
    {
      public StatId StatId;
      public int Value;
    }
  }
}