using Configs;
using Configs.Resources;
using Configs.Resources.PlayerConfigs.Scripts;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Rotators
{
  public class PlayerRotator : MonoBehaviour
  {
    private PlayerConfig _playerConfig;

    private float RotationSpeed => _playerConfig.RotationSpeed;

    [Inject]
    private void Construct(IStaticDataService staticData)
    {
      _playerConfig = staticData.ForPlayer();
    }

    public void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;
      
      if (direction == Vector3.zero)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
  }
}