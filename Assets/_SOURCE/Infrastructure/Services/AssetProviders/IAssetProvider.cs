using Gameplay.Characters.Enemies;
using UnityEngine;

namespace Infrastructure.Services.AssetProviders
{
  public interface IAssetProvider : IService
  {
    T Get<T>() where T : MonoBehaviour;
    T Get<T>(string path) where T : MonoBehaviour;
    Enemy ForEnemy(EnemyId enemyId);
  }
}