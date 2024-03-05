using System;
using Gameplay.Characters.Enemies;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.AssetProviders
{
  public class AssetProvider : IAssetProvider
  {
    public T Get<T>() where T : MonoBehaviour
    {
      if (Resources.Load(typeof(T).Name) == null)
      {
        throw new Exception("Asset not found: " + typeof(T).Name);
      }

      var load = Resources.Load(typeof(T).Name).GetComponent<T>();

      if (load == null)
      {
        throw new Exception("Asset not found: " + typeof(T).Name);
      }

      return load;
    }

    public T Get<T>(string path) where T : MonoBehaviour
    {
      var load = Resources.Load(path).GetComponent<T>();

      if (load == null)
      {
        throw new Exception("Asset not found: " + path);
      }

      return load;
    }

    public Enemy ForEnemy(EnemyId enemyId)
    {
      switch (enemyId)
      {
        case EnemyId.Unknown:
          throw new NotImplementedException("Unknown enemy id");

        case EnemyId.WhiteShirt:
          return Get<Enemy>(nameof(EnemyId.WhiteShirt));
        
        case EnemyId.Builderman:
          return Get<Enemy>(nameof(EnemyId.Builderman));

        default:
          throw new ArgumentOutOfRangeException(nameof(enemyId), enemyId, null);
      }
    }
  }
}