using Gameplay.CurrencyRepositories.BackpackStorages;
using Infrastructure.ConfigServices;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotator
  {
    private readonly ConfigService _static;
    private readonly PlayerProvider _playerProvider;

    public PlayerRotator(ConfigService configService, PlayerProvider playerProvider
    )
    {
      _static = configService;
      _playerProvider = playerProvider;
    }

    public void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;

      if (direction == Vector3.zero)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);
      _playerProvider.Instance.transform.rotation = Quaternion.Slerp(_playerProvider.Instance.transform.rotation, targetRotation, Time.deltaTime * _static.PlayerConfig.RotationSpeed);
    }
  }
}