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
    private IStaticDataService _staticData;

    private CharacterController _characterController;
    private float _rotationSpeed;
    private float _speed;

    [Inject]
    public void Construct(IInputService inputService, IStaticDataService progress)
    {
      _inputService = inputService;
      _staticData = progress;
    }

    private void Awake()
    {
      _characterController = GetComponent<CharacterController>();

      _speed = _staticData.ForPlayer().MoveSpeed;
      _rotationSpeed = _staticData.ForPlayer().RotationSpeed;
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
      Vector3 velocity = directionXYZ * _speed;
      _characterController.Move(velocity * Time.deltaTime);
    }

    private void RotateTowardsDirection(Vector3 direction)
    {
      const float MinLength = 0.01f;

      if (direction.sqrMagnitude < MinLength)
        return;

      Quaternion targetRotation = Quaternion.LookRotation(direction);

      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
  }
}