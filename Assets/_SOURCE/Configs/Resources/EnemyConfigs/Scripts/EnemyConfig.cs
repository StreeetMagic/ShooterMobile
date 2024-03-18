﻿using System.Collections.Generic;
using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Configs.Resources.EnemyConfigs.Scripts
{
  [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/EnemyConfig")]
  public class EnemyConfig : ScriptableObject
  {
    public EnemyId Id;
    public float MoveSpeed;
    public float RunSpeed;
    [Tooltip("Время бега после ранения")] public float RunTime;
    public float WaitTimeAfterMove;
    public int InitialHealth;
    public int MoneyReward;
    public float HealMultiplier;

    public List<LootDrop> LootDrops;
  }
}