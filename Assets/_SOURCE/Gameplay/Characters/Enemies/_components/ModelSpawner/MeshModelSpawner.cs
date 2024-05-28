using _Infrastructure.AssetProviders;
using _Infrastructure.ZenjectFactories;
using Gameplay.Characters.Enemies.Animators;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.ModelSpawner
{
  public class MeshModelSpawner : MonoBehaviour
  {
    [Inject] private IAssetProvider _assetProvider;
    [Inject] private EnemyId _enemyId;
    [Inject] private ShootingPoint _shootingPoint;
    [Inject] private GameLoopZenjectFactory _factory;
    [Inject] private EnemyAnimatorProvider _animatorProvider;

    private void OnEnable()
    {
      EnemyMeshModel prefab = _assetProvider.GetEnemyMeshModel(_enemyId);

      EnemyMeshModel meshModel = _factory.InstantiateMono(prefab, transform.position, transform);

      _shootingPoint.PointTransform = meshModel.GetComponent<ShootingPoint>().PointTransform;

      _animatorProvider.Instance = meshModel.GetComponent<EnemyAnimator>();
    }
  }
}