using Gameplay.Characters.Enemies;
using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

public class EnemyGrenadeThrower : MonoBehaviour
{
  [Inject] private PlayerProvider _playerProvider;
  [Inject] private EnemyConfig _config;

  private float _cooldownLeft;
  private bool _readyToThrow;

  public void Update()
  {
    if (_cooldownLeft > 0)
    {
      _cooldownLeft -= Time.deltaTime;
      _readyToThrow = false;
    }
    else if (_playerProvider.PlayerStandsOnSamePosition.TimeOnSamePosition >= _config.TargetStandsOnSamePositionTime)
    {
      _readyToThrow = true;
    }
  }

  public void Throw()
  {
    if (!_readyToThrow)
      return;

    _cooldownLeft = _config.GrenadeThrowCooldown;
  }
}