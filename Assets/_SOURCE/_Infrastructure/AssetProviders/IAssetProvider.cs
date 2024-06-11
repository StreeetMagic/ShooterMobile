using Gameplay.Characters.Enemies;
using UnityEngine;

namespace AssetProviders
{
  public interface IAssetProvider
  {
    T Get<T>() where T : MonoBehaviour;
    T Get<T>(string path) where T : MonoBehaviour;
    EnemyMeshModel GetEnemyMeshModel(EnemyTypeId enemyId);
    GameObject Get(string path);
  }
}