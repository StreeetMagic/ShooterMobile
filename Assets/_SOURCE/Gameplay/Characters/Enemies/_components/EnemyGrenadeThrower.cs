using Gameplay.Characters.Players;
using Gameplay.Grenades;
using StaticDataServices;
using UnityEngine;
using Zenject;
using ZenjectFactories;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyGrenadeThrower : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private GameLoopZenjectFactory _gameLoopZenjectFactory;
    [Inject] private IStaticDataService _staticDataService;
    [Inject] private EnemyConfig _config;
    [Inject] private Enemy _enemy;

    private float _grenadeCooldownLeft;
    private int _grenadesLeft;

    public bool ReadyToThrow => _grenadesLeft > 0 && _grenadeCooldownLeft <= 0 && TargetStandsOnSamePosition();
    public float RandomGrenadeDelay { get; private set; }

    private void Awake()
    {
      RandomGrenadeDelay = Random.Range(0, _config.GrenadeThrowRandomDelay);
      _grenadesLeft = _config.MaxGrenadesCount;
      _grenadeCooldownLeft = 0;
    }

    private void Update()
    {
      _grenadeCooldownLeft -= Time.deltaTime;
    }

    public void Lauch()
    {
      _grenadesLeft--;
      _grenadeCooldownLeft = _config.GrenadeThrowCooldown;

      GrenadeTypeId grenadeTypeId = _config.GrenadeTypeId;

      var grenade = _gameLoopZenjectFactory.InstantiateMono<Grenade>();

      Vector3 targetPosition = _playerProvider.Player.transform.position;

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
      _playerProvider.PlayerStandsOnSamePosition.TimeOnSamePosition >= _config.TargetStandsOnSamePositionTime;
  }
}