using Gameplay.Characters.Pets.Hens.MeshModels;
using Gameplay.Characters.Players;
using Gameplay.Stats;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenToPlayerFollower : MonoBehaviour
  {
    [Inject] private HenMover _henMover;
    [Inject] private PlayerStatsProvider _playerStatsProvider;
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HenRotator _henRotator;
    [Inject] private HenAnimator _henAnimator;

    private float MoveSpeed => _playerStatsProvider.GetStat(StatId.MoveSpeed).Value;
    private Transform Player => _playerProvider.Instance.transform;

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
}