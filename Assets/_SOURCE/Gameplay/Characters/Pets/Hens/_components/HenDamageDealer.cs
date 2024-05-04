using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Pets.Hens._components;
using Gameplay.Characters.Pets.Hens.MeshModels;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Pets.Hens
{
  public class HenDamageDealer : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HenSpawner _henSpawner;
    [Inject] private HenVisualEffector _henVisualEffector;
    [Inject] private Hen _hen;
    [Inject] private HenAnimator _henAnimator;

    private float _timeLeft;
    private bool _activated;

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

      RaycastHit[] targets = Physics.SphereCastAll(transform.position, 3f, Vector3.up);

      foreach (RaycastHit target in targets)
      {
        if (target.transform.TryGetComponent(out EnemyTargetTrigger enemyTargetTrigger))
        {
          int randomDamage = Random.Range(10, 51);

          enemyTargetTrigger.EnemyHealth.TakeDamage(randomDamage);

          enemyTargetTrigger.transform.parent.GetComponent<CharacterController>().Move((enemyTargetTrigger.transform.position - transform.position).normalized * 1f);
        }
      }

      _henSpawner.DeSpawn(_hen);
    }
  }
}