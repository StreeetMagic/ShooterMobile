using Gameplay.Characters.Players.TargetHolders;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerToTargetAggro : MonoBehaviour
  {
    [Inject] private PlayerTargetHolder _targetHolder;

    private void Update()
    {
      if (_targetHolder.HasTarget)
      {
        if (_targetHolder.CurrentTarget.HitStatus.IsHit == false)
        {
          float aggroDistance = _targetHolder.CurrentTarget.AggroRadius;

          if (Vector3.Distance(transform.position, _targetHolder.CurrentTarget.transform.position) < aggroDistance)
            _targetHolder.CurrentTarget.Health.NotifyOtherEnemies();
        }
      }
    }
  }
}