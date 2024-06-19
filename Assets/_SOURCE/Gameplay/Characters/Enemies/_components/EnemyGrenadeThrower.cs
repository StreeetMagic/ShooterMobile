using Gameplay.Characters.Players;
using Gameplay.Grenades;
using Infrastructure.ConfigServices;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies
{
  public class EnemyGrenadeThrower : IInitializable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;
    private readonly ConfigProvider _configProvider;
    private readonly EnemyConfig _config;
    private readonly Transform _transform;
    private readonly EnemyGrenadeStorage _grenadeStorage;

    public EnemyGrenadeThrower(PlayerProvider playerProvider, GameLoopZenjectFactory gameLoopZenjectFactory,
      ConfigProvider configProvider, EnemyConfig config, EnemyGrenadeStorage grenadeStorage, Transform transform)
    {
      _playerProvider = playerProvider;
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
      _configProvider = configProvider;
      _config = config;
      _grenadeStorage = grenadeStorage;
      _transform = transform;
    }

    public void Initialize()
    {
    }

    public void Lauch()
    {
      _grenadeStorage.SpendGrenade();

      GrenadeTypeId grenadeTypeId = _config.GrenadeTypeId;

      var grenade = _gameLoopZenjectFactory.InstantiateMono<Grenade>();
      grenade.transform.position = _transform.position;

      Vector3 targetPosition = _playerProvider.Instance.transform.position;

      var offset = .6f;

      float xOffset = Random.Range(-offset, offset);
      float zOffset = Random.Range(-offset, offset);

      Vector3 newPosition = new Vector3(targetPosition.x + xOffset, targetPosition.y, targetPosition.z + zOffset);

      var mover = grenade.GetComponent<GrenadeMover>();
      mover.Init(_configProvider.GetGrenadeConfig(grenadeTypeId), _transform.position, newPosition);

      var detonator = grenade.GetComponent<GrenadeDetonator>();
      detonator.Init(_configProvider.GetGrenadeConfig(grenadeTypeId));

      mover.Throw();
    }
  }
}