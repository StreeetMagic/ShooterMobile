using System;
using Gameplay.Characters.Enemies.EnemyShooters;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyShootAtPlayer : MonoBehaviour
  {
    private EnemyShooter _shooter;
    private Enemy _enemy;
    private float _time;
    private PlayerProvider _playerProvider;

    [Inject]
    public void Construct(EnemyShooter shooter, Enemy enemy, PlayerProvider playerProvider)
    {
      _shooter = shooter;
      _enemy = enemy;
      _playerProvider = playerProvider;
    }

    private float Cooldown => 1 / (float)_enemy.Config.FireRate;
    private Transform PlayerTransform => _playerProvider.Player.transform;

    private void OnEnable()
    {
      _time = 0;
    }

    private void Update()
    {
      _time += Time.deltaTime;

      if (_time >= Cooldown)
      {
        var distance = (PlayerTransform.position - transform.position).magnitude;

        if (distance <= _enemy.Config.Radius)
        {
          _shooter.Shoot();
          _time = 0;
        }
      }
    }
  }
}