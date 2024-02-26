using Infrastructure.Services.CurrentDatas;
using Infrastructure.Services.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Players
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerMover : MonoBehaviour
  {
    private IStaticDataService _staticDataService;
    private CharacterController _characterController;
    private Vector3 _cachedVelocity;

    private float RotationSpeed => _staticDataService.ForPlayer().RotationSpeed;
    private float MoveSpeed => _staticDataService.ForPlayer().MoveSpeed;
    private float GravityScale => _staticDataService.ForPlayer().GravityScale;

    [Inject]
    private void Construct(IStaticDataService staticData)
    {
      _staticDataService = staticData;
      _characterController = GetComponent<CharacterController>();
    }
    
    public void Move(Vector3 directionXYZ)
    {
      Vector3 playerSpeed = directionXYZ * (MoveSpeed * Time.deltaTime);
      Vector3 gravity = Physics.gravity * (GravityScale * Time.deltaTime);

      if (_characterController.isGrounded)
      {
        _cachedVelocity = playerSpeed;
        _characterController.Move(playerSpeed + Vector3.down);
      }
      else
      {
        _characterController.Move(gravity + _cachedVelocity);
      }
    }

    public void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);

      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
  }
}