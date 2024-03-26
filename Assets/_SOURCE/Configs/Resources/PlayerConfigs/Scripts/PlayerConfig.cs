using System;
using System.Collections.Generic;
using Configs.Resources.UpgradeConfigs.Scripts;
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

    public List<StatValuePair> Stats;

    [Serializable]
    public class StatValuePair
    {
      public StatId StatId;
      public int Value;
    }
  }
}