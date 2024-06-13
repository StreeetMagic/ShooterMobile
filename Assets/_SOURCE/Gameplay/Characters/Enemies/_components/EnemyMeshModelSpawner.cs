using Gameplay.Characters.Enemies.Animators;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeshModelSpawner
  {
    private EnemyMeshModelSpawner(
      AssetProvider assetProvider, 
      EnemyTypeId enemyId, 
      EnemyShootingPointProvider shootingPointProvider, 
      GameLoopZenjectFactory factory, 
      EnemyAnimatorProvider animatorProvider, 
      Transform transform)
    {
      EnemyMeshModel prefab = assetProvider.GetEnemyMeshModel(enemyId);
      
      EnemyMeshModel meshModel = factory.InstantiateMono(prefab, transform.position, transform);
      
      shootingPointProvider.PointTransform = meshModel.GetComponent<EnemyShootingPoint>().PointTransform;
      
      animatorProvider.Instance = meshModel.GetComponent<EnemyAnimator>();
    }
  }
}