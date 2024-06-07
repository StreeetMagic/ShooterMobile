using Gameplay.Characters.Pets.Hens._components;
using Gameplay.Characters.Pets.Hens.MeshModels;
using Gameplay.Characters.Players;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenDamageDealer : MonoBehaviour
  {
    private float _timeLeft;
    private bool _activated;

    readonly RaycastHit[] _targets = new RaycastHit[128];

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HenSpawner _henSpawner;
    [Inject] private HenVisualEffector _henVisualEffector;
    [Inject] private Hen _hen;
    [Inject] private HenAnimator _henAnimator;

    private Transform Target => _playerProvider.PlayerTargetHolder.CurrentTarget.transform;
    private bool HasTarget => _playerProvider.PlayerTargetHolder.HasTarget;

    private void Update()
    {
      if (HasTarget)
      {
        float distance = Vector3.Distance(Target.position, transform.position);

        if (distance < 1f)
        {
          if (_activated == false)
          {
            _timeLeft = _henAnimator.PlayBoomAnimation();

            _activated = true;
          }

          _timeLeft -= Time.deltaTime;

          if (_timeLeft <= 0 && _activated)
          {
            Boom();
          }
        }
      }
    }

    private void Boom()
    {
      _henVisualEffector.PlayExplosion();

      int hitCount = Physics.SphereCastNonAlloc(transform.position, 5f, transform.forward, _targets);

      for (var i = 0; i < hitCount; i++)
      {
        RaycastHit target = _targets[i];

        if (target.transform.TryGetComponent(out ITargetTrigger enemyTargetTrigger))
        {
          int randomDamage = Random.Range(10, 51);

          enemyTargetTrigger.Health.TakeDamage(randomDamage);

          enemyTargetTrigger.transform.parent.GetComponent<CharacterController>().Move((enemyTargetTrigger.transform.position - transform.position).normalized * 1f);
        }
      }

      _henSpawner.DeSpawn(_hen);
    }
  }
}