using Infrastructure.ConfigServices;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponLowerer
  {
    private readonly ConfigService _config;
    private readonly PlayerProvider _playerProvider;
    
    private float _timeLeft;
    private bool _isLowering;
    
    public PlayerWeaponLowerer(ConfigService config, PlayerProvider playerProvider)
    {
      _config = config;
      _playerProvider = playerProvider;
    }
    
    public bool IsLowered => _timeLeft <= 0;
    
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