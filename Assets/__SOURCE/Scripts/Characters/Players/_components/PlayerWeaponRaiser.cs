using Infrastructure.ConfigProviders;
using UnityEngine;

namespace Characters.Players._components
{
  public class PlayerWeaponRaiser
  {
    private readonly ConfigProvider _config;
    private readonly PlayerProvider _playerProvider;

    private float _timeLeft;
    private bool _isRising;

    public PlayerWeaponRaiser(ConfigProvider config, PlayerProvider playerProvider)
    {
      _config = config;
      _playerProvider = playerProvider;
    }

    public bool IsRaised => _timeLeft <= 0;

    public void ResetTime()
    {
      _timeLeft = _config.GetWeaponConfig(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).RaiseTime;
    }
    
    public void Tick()
    {
      if (_timeLeft > 0)
        _timeLeft -= Time.deltaTime;
      
      if (_timeLeft < 0)
        _timeLeft = 0;
    }
  }
}