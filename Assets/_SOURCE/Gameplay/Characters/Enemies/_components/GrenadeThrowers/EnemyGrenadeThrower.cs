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
  private float _randomDelay;
  private float _randomDelayLeft;
  private int _grenadesLeft;

  private void Start()
  {
    _randomDelay = Random.Range(0, _config.GrenadeThrowRandomDelay);
    _randomDelayLeft = _randomDelay;
    _grenadesLeft = _config.MaxGrenadesCount;
  }

  public void Update()
  {
    if (_cooldownLeft > 0)
    {
      _cooldownLeft -= Time.deltaTime;
      _readyToThrow = false;
    }
    else if (_playerProvider.PlayerStandsOnSamePosition.TimeOnSamePosition >= _config.TargetStandsOnSamePositionTime)
    {
      if (_randomDelayLeft > 0)
      {
        _randomDelayLeft -= Time.deltaTime;

        _readyToThrow = false;
      }
      else
      {
        _readyToThrow = true;
      }
    }
  }

  public void Throw()
  {
    if (!_readyToThrow)
      return;

    if (_grenadesLeft <= 0)
      return;

    _cooldownLeft = _config.GrenadeThrowCooldown;
    _randomDelayLeft = _randomDelay;
    _grenadesLeft--;
  }
}