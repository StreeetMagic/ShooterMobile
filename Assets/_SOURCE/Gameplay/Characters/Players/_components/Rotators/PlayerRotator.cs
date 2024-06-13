using Infrastructure.StaticDataServices;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotator
  {
    private readonly IStaticDataService _static;
    private readonly PlayerProvider _playerProvider;

    public PlayerRotator(IStaticDataService staticDataService, PlayerProvider playerProvider)
    {
      _static = staticDataService;
      _playerProvider = playerProvider;
    }

    private float RotationSpeed => _static.GetPlayerConfig().RotationSpeed;
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