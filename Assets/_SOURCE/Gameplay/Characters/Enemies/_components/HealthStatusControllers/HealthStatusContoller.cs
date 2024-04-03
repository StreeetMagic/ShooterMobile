using System.Collections;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.CoroutineRunners;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class HitStatus
  {
    public bool IsHit { get; set; }
  }
}