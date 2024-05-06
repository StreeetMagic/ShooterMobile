using Configs.Resources.StatConfigs;
using Gameplay.Characters.Pets.Hens.MeshModels;
using Gameplay.Characters.Players.Factories;
using Gameplay.Characters.Players.PlayerStatsProviders;
using UnityEngine;
using Zenject;

public class HenToPlayerFollower : MonoBehaviour
{
  [Inject] private HenMover _henMover;
  [Inject] private PlayerStatsProvider _playerStatsProvider;
  [Inject] private PlayerProvider _playerProvider;
  [Inject] private HenRotator _henRotator;
  [Inject] private HenAnimator _henAnimator;

  private int MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
  private Transform Player => _playerProvider.Player.transform;

  private void Awake()
  {
     enabled = false;
  }

  private void OnEnable()
  {
    _henAnimator.PlayWalkAnimation();
  }

  private void Update()
  {
    _henMover.Move(Player.position, MoveSpeed);
    _henRotator.Rotate(Player.position);
  }
}