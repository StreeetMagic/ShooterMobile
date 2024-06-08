using Gameplay.Characters.Players;
using Gameplay.Grenades;
using StaticDataServices;
using UnityEngine;
using Zenject;
using ZenjectFactories;

namespace Gameplay.Characters.Enemies.States
{
  public class EnemyGrenadeLauncher : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private GameLoopZenjectFactory _gameLoopZenjectFactory;
    [Inject] private IStaticDataService _staticDataService;
    [Inject] private EnemyConfig _config;
    [Inject] private Enemy _enemy;

    public void Lauch()
    {
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
  }
}