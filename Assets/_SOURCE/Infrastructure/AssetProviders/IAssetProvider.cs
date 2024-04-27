using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Infrastructure.AssetProviders
{
  public interface IAssetProvider
  {
    T Get<T>() where T : MonoBehaviour;
    T Get<T>(string path) where T : MonoBehaviour;
    EnemyMeshModel GetEnemyMeshModel(EnemyId enemyId);
    GameObject Get(string path);
  }
}