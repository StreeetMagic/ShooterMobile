using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.PlayerStatsProviders;
using Gameplay.Stats;
using Projects;
using SaveLoadServices;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Movers
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerMover : MonoBehaviour, IProgressWriter
  {
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Vector3 _cachedVelocity;
    private Vector3 _gravitySpeed;

    [Inject] private readonly CharacterController _characterController;
    [Inject] private readonly PlayerStatsProvider _playerStatsProvider;
    [Inject] private readonly IStaticDataService _staticDataService;

    private PlayerConfig PlayerConfig => _staticDataService.GetPlayerConfig();
    private float MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
    private float GravityScale => PlayerConfig.GravityScale;

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

    public void ReadProgress(ProjectProgress projectProgress)
    {
      if (_characterController == null)
        return;

      _characterController.enabled = false;
      transform.position = projectProgress.PlayerPosition;
      _characterController.enabled = true;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.PlayerPosition = transform.position;
    }
  }
}