using System;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.AssetProviders
{
  public class AssetProvider : IAssetProvider
  {
    public T Get<T>() where T : MonoBehaviour
    {
      if (Resources.Load(typeof(T).Name) == null)
        throw new Exception("Asset not found: " + typeof(T).Name);

      var load =
        Resources
          .Load(typeof(T).Name)
          .GetComponent<T>();

      if (load == null)
        throw new Exception("Asset not found: " + typeof(T).Name);

      return load;
    }

    public T Get<T>(string path) where T : MonoBehaviour
    {
      var load =
        Resources
          .Load(path)
          .GetComponent<T>();

      if (load == null)
        throw new Exception("Asset not found: " + path);

      return load;
    }

    public GameObject Get(string path)
    {
      Object load =
        Resources
          .Load(path);
      
      if (load == null)
        throw new Exception("Asset not found: " + path);
      
      return load as GameObject;
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