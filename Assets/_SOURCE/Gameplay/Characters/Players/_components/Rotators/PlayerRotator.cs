using Infrastructure.ConfigServices;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotator
  {
    private readonly ConfigService _static;
    private readonly PlayerProvider _playerProvider;

    public PlayerRotator(ConfigService configService, PlayerProvider playerProvider)
    {
      _static = configService;
      _playerProvider = playerProvider;
    }

    private float RotationSpeed => _static.PlayerConfig.RotationSpeed;
    private Transform Transform => _playerProvider.Instance.transform;

    public void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;

      if (direction == Vector3.zero)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);
      Transform.rotation = Quaternion.Slerp(Transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
  }
}