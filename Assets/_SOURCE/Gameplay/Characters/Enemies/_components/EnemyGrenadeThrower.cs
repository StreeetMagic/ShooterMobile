using Gameplay.Characters.Players;
using Gameplay.Grenades;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies
{
  public class EnemyGrenadeThrower : IInitializable, ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly GameLoopZenjectFactory _gameLoopZenjectFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly EnemyConfig _config;
    private readonly Enemy _enemy;

    private float _grenadeCooldownLeft;
    private int _grenadesLeft;

    public EnemyGrenadeThrower(PlayerProvider playerProvider, GameLoopZenjectFactory gameLoopZenjectFactory, IStaticDataService staticDataService,
      EnemyConfig config, Enemy enemy)
    {
      _playerProvider = playerProvider;
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
      _staticDataService = staticDataService;
      _config = config;
      _enemy = enemy;
    }

    public bool ReadyToThrow => _grenadesLeft > 0 && _grenadeCooldownLeft <= 0 && TargetStandsOnSamePosition();
    public float RandomGrenadeDelay { get; private set; }

    public void Initialize()
    {
      RandomGrenadeDelay = Random.Range(0, _config.GrenadeThrowRandomDelay);
      _grenadesLeft = _config.MaxGrenadesCount;
      _grenadeCooldownLeft = 0;
    }

    public void Tick()
    {
      _grenadeCooldownLeft -= Time.deltaTime;
    }

    public void Lauch()
    {
      _grenadesLeft--;
      _grenadeCooldownLeft = _config.GrenadeThrowCooldown;

      GrenadeTypeId grenadeTypeId = _config.GrenadeTypeId;

      var grenade = _gameLoopZenjectFactory.InstantiateMono<Grenade>();

      Vector3 targetPosition = _playerProvider.Instance.transform.position;

      var offset = .6f;

      float xOffset = Random.Range(-offset, offset);
      float zOffset = Random.Range(-offset, offset);

      Vector3 newPosition = new Vector3(targetPosition.x + xOffset, targetPosition.y, targetPosition.z + zOffset);

      var mover = grenade.GetComponent<GrenadeMover>();
      mover.Init(_staticDataService.GetGrenadeConfig(grenadeTypeId), _enemy.transform.position, newPosition);

      var detonator = grenade.GetComponent<GrenadeDetonator>();
      detonator.Init(_staticDataService.GetGrenadeConfig(grenadeTypeId));

      mover.Throw();
    }

    private bool TargetStandsOnSamePosition() =>
      _playerProvider.Instance.StandsOnSamePosition.TimeOnSamePosition >= _config.TargetStandsOnSamePositionTime;
  }
}