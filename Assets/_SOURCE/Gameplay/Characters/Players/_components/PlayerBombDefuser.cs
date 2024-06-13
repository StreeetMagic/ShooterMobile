using System;
using System.Collections.Generic;
using Gameplay.Bombs;
using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerBombDefuser : ITickable, IInitializable, IDisposable
  {
    private readonly PlayerHealth _playerHealth;
    private readonly PlayerMoveSpeed _playerMoveSpeed;
    private readonly ConfigService _configService;

    public PlayerBombDefuser(PlayerHealth playerHealth, PlayerMoveSpeed playerMoveSpeed, ConfigService configService)
    {
      _playerHealth = playerHealth;
      _playerMoveSpeed = playerMoveSpeed;
      _configService = configService;
    }

    public List<Bomb> Bombs { get; } = new();

    public void Initialize()
    {
      _playerHealth.Damaged += OnDamaged;
    }

    public void Tick()
    {
      if (_playerMoveSpeed.CurrentMoveSpeed.Value == 0)
      {
        float progressPerFrame = (Time.deltaTime / _configService.PlayerConfig.BombDefuseDuration);

        if (Bombs.Count <= 0)
          return;

        if (Bombs[0] != null)
          Bombs[0].GetComponent<BombDefuser>().DefuseProgress += progressPerFrame;
      }
      else
      {
        if (Bombs.Count <= 0)
          return;

        if (Bombs[0] != null)
          Bombs[0].GetComponent<BombDefuser>().DefuseProgress = 0;
      }
    }

    public void Dispose()
    {
      _playerHealth.Damaged -= OnDamaged;
    }

    private void OnDamaged(float obj)
    {
      if (Bombs.Count <= 0)
        return;

      if (Bombs[0] != null)
        Bombs[0].GetComponent<BombDefuser>().DefuseProgress = 0;
    }
  }
}