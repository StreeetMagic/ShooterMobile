using System;
using Configs.Resources.VisualEffectConfigs;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters.Projectiles
{
  public class Projectile : MonoBehaviour
  {
    private VisualEffectFactory _visualEffectFactory;

    [Inject]
    private void Construct(VisualEffectFactory visualEffectFactory)
    {
      _visualEffectFactory = visualEffectFactory;
    }

    private void OnCollisionEnter(Collision other)
    {
      _visualEffectFactory.Create(VIsualEffectId.BulletImpact, transform.position, transform);
      Destroy(gameObject);
    }

    public string Guid { get; set; }
  }
}