using Gameplay.Characters.Players.Animators;
using Infrastructure.Services.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Movers
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerMover : MonoBehaviour
  {
    [SerializeField] private PlayerAnimator _playerAnimator;
    
    private CharacterController _characterController;
    private PlayerConfig _playerConfig;
    
    private Vector3 _cachedVelocity;
    private Vector3 _gravitySpeed;

    private float MoveSpeed => _playerConfig.MoveSpeed;
    private float GravityScale => _playerConfig.GravityScale;

    [Inject]
    private void Construct(IStaticDataService staticData)
    {
      _playerConfig = staticData.ForPlayer();
      _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 directionXYZ)
    {
      Vector3 playerSpeed = directionXYZ * (MoveSpeed * Time.deltaTime);

      if (directionXYZ.magnitude > 0.01)
      {
        _playerAnimator.PlayRunAnimation();
      }
      else
      {
        _playerAnimator.Stop();
      }
      
      if (_characterController.isGrounded)
      {
        _cachedVelocity = playerSpeed;
        _characterController.Move(playerSpeed + Vector3.down);

        _gravitySpeed = Vector3.zero;
      }
      else
      {
        ApplyGravity();
        _characterController.Move(_cachedVelocity + _gravitySpeed);
      }
    }

    private void ApplyGravity()
    {
      _gravitySpeed += Physics.gravity * GravityScale * Time.deltaTime;
    }
  }
}