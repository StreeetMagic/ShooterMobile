using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies.TargetTriggers
{
  public class EnemyToPlayerRotator : MonoBehaviour
  {
    [Inject] private Enemy _enemy;
    [Inject] private PlayerProvider _playerProvider;

    public void Rotate()
    {
      Vector3 target = _playerProvider.Player.transform.position;

      Vector3 direction = target - _enemy.transform.position;

      _enemy.transform.rotation = Quaternion.LookRotation(direction);
    }
  }
}