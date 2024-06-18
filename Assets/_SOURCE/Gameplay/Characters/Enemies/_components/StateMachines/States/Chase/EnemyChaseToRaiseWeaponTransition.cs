using Gameplay.Characters.Enemies.StateMachines.States.RaiseWeapon;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Chase
{
  public class EnemyChaseToRaiseWeaponTransition : Transition
  {
    private readonly EnemyConfig _config;
    private readonly Transform _transform;
    private readonly PlayerProvider _playerProvider;

    public EnemyChaseToRaiseWeaponTransition(EnemyConfig config, Transform transform, PlayerProvider playerProvider)
    {
      _config = config;
      _transform = transform;
      _playerProvider = playerProvider;
    }

    public override void Tick()
    {
      if (Vector3.Distance(_transform.position, _playerProvider.Instance.Transform.position) < _config.ShootRange)
        Enter<EnemyRaiseWeaponState>();
    }
  }
}