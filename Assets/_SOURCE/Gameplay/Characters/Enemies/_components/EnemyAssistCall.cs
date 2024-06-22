using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Spawners;
using Gameplay.Spawners.SpawnerFactories;
using Infrastructure.Projects;
using Infrastructure.SceneLoaders;
using Maps;
using Scenes._Infrastructure.Scripts;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyAssistCall
  {
    private const int OverlapCount = 200;

    private readonly Transform _transform;
    private readonly EnemyConfig _enemyConfig;
    private readonly SceneLoader _sceneLoader;
    private readonly ProjectData _projectData;
    private readonly EnemySpawnerFactory _spawners;

    private readonly Collider[] _enemies;

    public EnemyAssistCall(Transform transform, EnemyConfig enemyConfig,
      SceneLoader sceneLoader, ProjectData projectData, EnemySpawnerFactory spawners)
    {
      _transform = transform;
      _enemyConfig = enemyConfig;
      _sceneLoader = sceneLoader;
      _projectData = projectData;
      _spawners = spawners;

      _enemies = new Collider[OverlapCount];
    }

    public void Call()
    {
      if (_projectData.GetGameLoopSceneTypeId(_sceneLoader.CurrentScene) == GameLoopSceneTypeId.Arena)
      {
        foreach (EnemySpawner spawner in _spawners.Spawners)
        {
          foreach (Enemy enemy in spawner.Enemies)
          {
            enemy.Health.Hit();
          }
        }
      }
      else
      {
        int count = Physics.OverlapSphereNonAlloc(_transform.position, _enemyConfig.AssistCallRadius, _enemies);

        for (int i = 0; i < count; i++)
          if (_enemies[i].TryGetComponent(out EnemyTargetTrigger enemyTargetTrigger))
            enemyTargetTrigger.transform.parent.GetComponent<Enemy>().Health.Hit();
      }
    }
  }
}