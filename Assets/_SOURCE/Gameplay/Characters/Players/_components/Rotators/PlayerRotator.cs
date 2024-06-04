using StaticDataServices;
using UnityEngine;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotator
  {
    private readonly IStaticDataService _static;
    private readonly Transform _transform;
    
    public PlayerRotator(IStaticDataService staticDataService, Transform transform)
    {
      _static = staticDataService;
      _transform = transform;
    }

    private float RotationSpeed => _static.GetPlayerConfig().RotationSpeed;

    public void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;

      if (direction == Vector3.zero)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);
      _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
  }
}