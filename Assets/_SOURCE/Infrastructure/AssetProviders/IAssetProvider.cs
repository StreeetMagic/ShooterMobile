using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Infrastructure.AssetProviders
{
  public interface IAssetProvider
  {
    T Get<T>() where T : MonoBehaviour;
    T Get<T>(string path) where T : MonoBehaviour;
    GameObject Get(string path);
    Enemy ForEnemy(EnemyId enemyId);
  }
}