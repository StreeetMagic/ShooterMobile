using Gameplay.Characters.Enemies;
using UnityEngine;

namespace _Infrastructure.AssetProviders
{
  public interface IAssetProvider
  {
    T Get<T>() where T : MonoBehaviour;
    T Get<T>(string path) where T : MonoBehaviour;
    EnemyMeshModel GetEnemyMeshModel(EnemyId enemyId);
    GameObject Get(string path);
  }
}