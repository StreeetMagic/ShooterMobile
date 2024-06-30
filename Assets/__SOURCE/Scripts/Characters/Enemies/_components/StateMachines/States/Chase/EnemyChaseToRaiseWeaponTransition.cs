using Characters.Enemies._components.StateMachines.States.RaiseWeapon;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Characters.Players;
using UnityEngine;

namespace Characters.Enemies._components.StateMachines.States.Chase
{
  public class EnemyChaseToRaiseWeaponTransition : Transition
  {
    private readonly EnemyConfig _config;
    private readonly Transform _transform;
    private readonly PlayerProvider _playerProvider;
    private readonly EnemyWeaponMagazine _magazine;

    public EnemyChaseToRaiseWeaponTransition(EnemyConfig config, Transform transform, 
      PlayerProvider playerProvider, EnemyWeaponMagazine magazine)
    {
      _config = config;
      _transform = transform;
      _playerProvider = playerProvider;
      _magazine = magazine;
    }

    public override void Tick()
    {
      if (_config.IsShooter == false)
        return;
      
      if (_magazine.IsEmpty)
        return;
      
      if (Vector3.Distance(_transform.position, _playerProvider.Instance.Transform.position) + 1 < _config.ShootRange)
        Enter<EnemyRaiseWeaponState>();
    }
  }
}