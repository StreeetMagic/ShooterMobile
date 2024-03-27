using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;
using UnityEngine.Serialization;

public class ActorUserInterface : MonoBehaviour
{
  [FormerlySerializedAs("Health")] public EnemyHealth enemyHealth;

  private void OnEnable()
  {
    enemyHealth.Died += OnDied;
  }

  private void OnDisable()
  {
    enemyHealth.Died -= OnDied;
  }

  private void OnDied(EnemyConfig arg1, EnemyHealth arg2)
  {
    gameObject.SetActive(false);
  }
}