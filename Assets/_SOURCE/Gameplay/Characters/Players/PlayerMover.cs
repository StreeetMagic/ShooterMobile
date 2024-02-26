using Infrastructure.Services.CurrentDatas;
using Infrastructure.Services.Inputs;
using Infrastructure.Services.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Players
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerMover : MonoBehaviour
  {
    private IInputService _inputService;
    private IStaticDataService _staticDataService;
    private CharacterController _characterController;
    private Vector3 _cachedVelocity;

    private float RotationSpeed => _staticDataService.ForPlayer().RotationSpeed;
    private float MoveSpeed => _staticDataService.ForPlayer().MoveSpeed;
    private float GravityScale => _staticDataService.ForPlayer().GravityScale;

    [Inject]
    public void Construct(IInputService inputService, IStaticDataService staticData)
    {
      _inputService = inputService;
      _staticDataService = staticData;
      _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
      MoveAndRotate();
    }

    private void MoveAndRotate()
    {
      if (_inputService.CanMove == false)
        return;

      Vector3 direction = GetDirection();
      Move(direction);
      RotateTowardsDirection(direction);
    }

    private Vector3 GetDirection()
    {
      Vector2 directionXY = _inputService.MoveDirection;

      return new Vector3(directionXY.x, 0, directionXY.y);
    }

    private void Move(Vector3 directionXYZ)
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

    private void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);

      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
  }
}