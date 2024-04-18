using System.Collections;
using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Infrastructure.DataRepositories;
using UnityEngine;
using Zenject;

public class EnemyExpirience : MonoBehaviour
{
  private ExpierienceStorage _expierienceStorage;
  private EnemyHealth _enemyHealth;

  [Inject]
  public void Construct(ExpierienceStorage expierienceStorage, EnemyHealth enemyHealth)
  {
    _expierienceStorage = expierienceStorage;
    _enemyHealth = enemyHealth;
  }

  private void OnEnable()
  {
    _enemyHealth.Died += OnDied;
  }

  private void OnDisable()
  {
    _enemyHealth.Died -= OnDied;
  }

  private void OnDied(EnemyConfig config, EnemyHealth health)
  {
    _expierienceStorage.AllPoints.Value += config.Expirience;
  }
}