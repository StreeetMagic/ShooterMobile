﻿using Configs.Resources.SoundConfigs.Scripts;
using DataRepositories.BackpackStorages;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.Projectiles.Scripts;
using Gameplay.Characters.Players.TargetHolders;
using Infrastructure.AudioServices;
using Infrastructure.StaticDataServices;
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

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;
    private Transform Transform => _playerProvider.ShootingPoint;
    private float Cooldown => 1 / _staticDataService.GetPlayerConfig().FireRate;

    public void Update()
    {
      if (_backpackStorage.IsFull)
        return;

      if (_playerProvider.Player == null)
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
      Vector3 directionToTarget = PlayerTargetHolder.DirectionToTarget;
      _projectileFactory.CreatePlayerProjectile(Transform, directionToTarget);
      _audioService.PlaySound(SoundId.Shoot);
    }
  }
}