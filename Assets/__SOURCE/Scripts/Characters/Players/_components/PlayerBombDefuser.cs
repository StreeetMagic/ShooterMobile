using System;
using System.Collections.Generic;
using Bombs;
using Infrastructure.ConfigProviders;
using UnityEngine;
using Zenject;

namespace Characters.Players._components
{
  public class PlayerBombDefuser : ITickable, IInitializable, IDisposable
  {
    private readonly PlayerHealth _playerHealth;
    private readonly PlayerMoveSpeed _playerMoveSpeed;
    private readonly ConfigProvider _configProvider;

    public PlayerBombDefuser(PlayerHealth playerHealth, PlayerMoveSpeed playerMoveSpeed, ConfigProvider configProvider)
    {
      _playerHealth = playerHealth;
      _playerMoveSpeed = playerMoveSpeed;
      _configProvider = configProvider;
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
        float progressPerFrame = (Time.deltaTime / _configProvider.PlayerConfig.BombDefuseDuration);

        if (Bombs.Count <= 0)
          return;

        if (Bombs[0] != null)
          Bombs[0].Defuser.DefuseProgress += progressPerFrame;
      }
      else
      {
        if (Bombs.Count <= 0)
          return;

        if (Bombs[0] != null)
          Bombs[0].Defuser.DefuseProgress = 0;
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
        Bombs[0].Defuser.DefuseProgress = 0;
    }
  }
}