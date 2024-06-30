using Infrastructure.ConfigProviders;
using UnityEngine;

namespace Characters.Players._components
{
  public class PlayerRotator
  {
    private readonly ConfigProvider _static;
    private readonly PlayerProvider _playerProvider;

    public PlayerRotator(ConfigProvider configProvider, PlayerProvider playerProvider
    )
    {
      _static = configProvider;
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