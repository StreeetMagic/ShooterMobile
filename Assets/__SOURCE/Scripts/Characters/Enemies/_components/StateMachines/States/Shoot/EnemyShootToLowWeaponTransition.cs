using Characters.Enemies._components.StateMachines.States.LowWeapon;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;
using Characters.Players;
using UnityEngine;

namespace Characters.Enemies._components.StateMachines.States.Shoot
{
  public class EnemyShootToLowWeaponTransition : Transition
  {
    private readonly PlayerProvider _playerProvider;
    private readonly Transform _transform;
    private readonly EnemyConfig _config;
    private readonly EnemyWeaponMagazine _magazine;

    public EnemyShootToLowWeaponTransition(PlayerProvider playerProvider,
      Transform transform, EnemyConfig config, EnemyWeaponMagazine magazine)
    {
      _playerProvider = playerProvider;
      _transform = transform;
      _config = config;
      _magazine = magazine;
    }

    public override void Tick()
    {
      if (_magazine.IsEmpty)
      {
        Enter<EnemyLowWeaponState>();

        return;
      }

      if (Vector3.Distance(_transform.position, _playerProvider.Instance.transform.position) - 1 > _config.ShootRange)
      {
        Enter<EnemyLowWeaponState>();
      }
    }
  }
}