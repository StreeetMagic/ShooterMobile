using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerToTargetAggro : ITickable
  {
    private readonly PlayerTargetHolder _targetHolder;
    private readonly Transform _transform;

    public PlayerToTargetAggro(PlayerTargetHolder targetHolder, Transform transform)
    {
      _targetHolder = targetHolder;
      _transform = transform;
    }

    public void Tick()
    {
      if (_targetHolder.HasTarget)
      {
        if (_targetHolder.CurrentTarget.HitStatus.IsHit == false)
        {
          float aggroDistance = _targetHolder.CurrentTarget.AggroRadius;

          if (Vector3.Distance(_transform.position, _targetHolder.CurrentTarget.transform.position) < aggroDistance)
            _targetHolder.CurrentTarget.Health.NotifyOtherEnemies();
        }
      }
    }
  }
}