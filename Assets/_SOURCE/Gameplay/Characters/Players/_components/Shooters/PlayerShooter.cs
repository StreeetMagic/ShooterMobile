using AudioServices;
using CurrencyRepositories.BackpackStorages;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Projectiles.Scripts;
using Sounds;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerShooter : MonoBehaviour
  {
    private float _timeLeft;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private IStaticDataService _staticDataService;
    [Inject] private ProjectileFactory _projectileFactory;
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private AudioService _audioService;
    [Inject] private PlayerWeaponRaiser _playerWeaponRaiser;

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Transform Transform => _playerProvider.WeaponShootingPointPoint.Transform;
    private float Cooldown => 1 / _staticDataService.GetPlayerConfig().FireRate;

    private void Update()
    {
      if (_backpackStorage.IsFull)
        return;

      if (_playerProvider.Player == null)
        return;

      if (_playerWeaponRaiser.IsRaised == false)
        return;

      if (PlayerTargetHolder.HasTarget)
        Shooting();
    }

    private void Shooting()
    {
      if (_timeLeft > 0)
      {
        _timeLeft -= Time.deltaTime;
        return;
      }

      Shoot();

      _timeLeft = Cooldown;
    }

    private void Shoot()
    {
      for (int i = 0; i < 1; i++)
      {
        Vector3 directionToTarget = PlayerTargetHolder.DirectionToTarget;

        directionToTarget = AddAngle(directionToTarget, 4f);

        _projectileFactory.CreatePlayerProjectile(Transform, directionToTarget);
        _audioService.PlaySound(SoundId.Shoot);
      }
    }

    private Vector3 AddAngle(Vector3 directionToTarget, float angle)
    {
      float randomHorizontalAngle = Random.Range(-angle, angle);
      float randomVerticalAngle = Random.Range(-angle, angle);

      Quaternion horizontalRotation = Quaternion.AngleAxis(randomHorizontalAngle, Vector3.up);
      Quaternion verticalRotation = Quaternion.AngleAxis(randomVerticalAngle, Vector3.right);

      directionToTarget = horizontalRotation * directionToTarget;
      directionToTarget = verticalRotation * directionToTarget;

      return directionToTarget.normalized;
    }
  }
}