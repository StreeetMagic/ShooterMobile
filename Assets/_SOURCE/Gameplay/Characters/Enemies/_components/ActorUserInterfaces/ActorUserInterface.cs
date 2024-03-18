using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using UnityEngine;

public class ActorUserInterface : MonoBehaviour
{
  public Health Health;

  private void OnEnable()
  {
    Health.Died += OnDied;
  }

  private void OnDisable()
  {
    Health.Died -= OnDied;
  }

  private void OnDied(EnemyConfig arg1, Health arg2)
  {
    gameObject.SetActive(false);
  }
}