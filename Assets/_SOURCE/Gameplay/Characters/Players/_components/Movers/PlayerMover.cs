using Configs.Resources;
using Configs.Resources.PlayerConfigs.Scripts;
using Configs.Resources.UpgradeConfigs.Scripts;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Characters.Players.Animators;
using Gameplay.Upgrades;
using Infrastructure.DataRepositories;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Movers
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerMover : MonoBehaviour, IProgressWriter
  {
    [SerializeField] private PlayerAnimator _playerAnimator;

    private CharacterController _characterController;
    private PlayerConfig _playerConfig;
    private MoneyInBankStorage _moneyInBankStorage;
    private UpgradeService _upgradeService;
    private PlayerStatsProvider _playerStatsProvider;

    private Vector3 _cachedVelocity;
    private Vector3 _gravitySpeed;

    [Inject]
    private void Construct(IStaticDataService staticData, MoneyInBankStorage moneyInBankStorage, UpgradeService upgradeService, PlayerStatsProvider playerStatsProvider)
    {
      _playerConfig = staticData.GetPlayerConfig();
      _moneyInBankStorage = moneyInBankStorage;
      _characterController = GetComponent<CharacterController>();
      _upgradeService = upgradeService;
      _playerStatsProvider = playerStatsProvider;
    }

    private float MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
    private float GravityScale => _playerConfig.GravityScale;

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

    public void ReadProgress(Progress progress)
    {
      transform.position = progress.PlayerPosition;
    }

    public void WriteProgress(Progress progress)
    {
      progress.PlayerPosition = transform.position;
    }
  }
}