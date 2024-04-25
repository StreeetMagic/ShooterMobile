using System.Collections.Generic;
using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace UserInterface.HeadsUpDisplays.MoneyAttractions
{
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
      List<EnemySpawner> spawners = _enemySpawnerFactory.Spawners;

      foreach (EnemySpawner spawner in spawners)
      {
        spawner.EnemyDied += OnEnemyDied;
      }
    }

    private void OnEnemyDied(EnemyHealth enemyHealth)
    {
      Vector3 position = _camera.WorldToScreenPoint(enemyHealth.transform.position);

      _visualEffectFactory.Create(VIsualEffectId.MoneyCollection1, position, transform, Target);
    }
  }
}