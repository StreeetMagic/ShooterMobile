using System;
using System.Collections;
using System.Collections.Generic;
using AssetKits.ParticleImage;
using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using UnityEngine;
using Zenject;

public class MoneyCollection : MonoBehaviour
{
  public Transform Target;
  
  private EnemySpawnerFactory _enemySpawnerFactory;
  private Camera _camera;
  private VisualEffectFactory _visualEffectFactory;

  [Inject]
  public void Construct(EnemySpawnerFactory enemySpawnerFactory, VisualEffectFactory visualEffectFactory)
  {
    _visualEffectFactory = visualEffectFactory;
    _enemySpawnerFactory = enemySpawnerFactory;
    _camera = Camera.main;
  }

  private void Start()
  {
    var spawners = _enemySpawnerFactory.Spawners;

    foreach (var spawner in spawners)
    {
      spawner.EnemyDied += OnEnemyDied;
    }
  }

  private void OnEnemyDied(Health health)
  {
    var position = _camera.WorldToScreenPoint(health.transform.position);

    _visualEffectFactory.Create(VIsualEffectId.MoneyCollection1, position, transform, Target);
  }
}