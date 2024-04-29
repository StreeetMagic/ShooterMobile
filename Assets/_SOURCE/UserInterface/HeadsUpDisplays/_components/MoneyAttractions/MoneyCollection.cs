using System.Collections.Generic;
using Configs.Resources.ParticleImageConfigs;
using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using Infrastructure;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;
using Zenject;
using Zenject.Source.Util;

namespace UserInterface.HeadsUpDisplays.MoneyAttractions
{
  public class MoneyCollection : MonoBehaviour
  {
    public Transform Target;
    public ParticleImage ParticleImage;
    public Animator Animator;

    private EnemySpawnerFactory _enemySpawnerFactory;
    private Camera _camera;
    private ParticleImageFactory _particleImageFactory;

    [Inject]
    public void Construct(EnemySpawnerFactory enemySpawnerFactory, ParticleImageFactory particleImageFactory)
    {
      _enemySpawnerFactory = enemySpawnerFactory;
      _particleImageFactory = particleImageFactory;
      _camera = Camera.main;
    }

    private void Start()
    {
      List<EnemySpawner> spawners = _enemySpawnerFactory.Spawners;

      foreach (EnemySpawner spawner in spawners)
      {
        spawner.EnemyDied += OnEnemyDied;
      }

      PlayerMoneyParticle(_camera.WorldToScreenPoint(Target.position));
    }

    private void OnEnemyDied(EnemyHealth enemyHealth)
    {
      Vector3 position = _camera.WorldToScreenPoint(enemyHealth.transform.position);

      Debug.Log(Target.position);

      //TODO: Valera ищет как достать эти числа из particleImage
      ParticleImage particleImage = PlayerMoneyParticle(position);

      int count = 5;
      float cooldown = .1f;
      float duration = 1.7f;

      for (float i = 0; i < count; i++)
      {
        Invoke(nameof(PlayBarParticle), i * cooldown + duration);
      }
    }

    private ParticleImage PlayerMoneyParticle(Vector3 position)
    {
      return _particleImageFactory.Create(ParticleImageId.MoneyCollection1, position, transform, Target);
    }

    private void PlayBarParticle()
    {
      ParticleImage.Play();
      Animator.SetTrigger("Bounce");
    }
  }
}