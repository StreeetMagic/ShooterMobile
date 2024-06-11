using AssetProviders;
using Gameplay.Characters.Enemies.Animators;
using UnityEngine;
using ZenjectFactories;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMeshModelSpawner
  {
    private EnemyMeshModelSpawner(
      IAssetProvider assetProvider, 
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