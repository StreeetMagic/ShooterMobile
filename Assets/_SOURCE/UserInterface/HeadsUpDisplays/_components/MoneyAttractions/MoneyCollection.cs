using System.Collections.Generic;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Enemies.Spawners.SpawnerFactories;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;
using UserInterface.HeadsUpDisplays.BackpackBars;
using VisualEffects;
using Zenject;

namespace UserInterface.HeadsUpDisplays.MoneyAttractions
{
  public class MoneyCollection : MonoBehaviour
  {
    public Transform Target;
    public ParticleImage ParticleImage;
    public BackpackBarBounceEffect BounceEffect;

    private Camera _camera;

    [Inject] private EnemySpawnerFactory _enemySpawnerFactory;
    [Inject] private ParticleImageFactory _particleImageFactory;

    //private static readonly int s_bounce = BounceEffect.StringToHash("Bounce");

    private void Awake()
    {
      ParticleImage.gameObject.SetActive(false);
      _camera = Camera.main;
    }

    private void Start()
    {
      List<EnemySpawner> spawners = _enemySpawnerFactory.Spawners;
    
      foreach (EnemySpawner spawner in spawners)
      {
        spawner.EnemyDied += OnEnemyDied;
      }
    }

    private void OnEnemyDied(EnemyHealth enemyHealth)
    {
      Vector3 position = _camera.WorldToScreenPoint(enemyHealth.transform.position);

      //TODO: Valera ищет как достать эти числа из particleImage
      // ReSharper disable once UnusedVariable
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
      ParticleImage playerMoneyParticle = _particleImageFactory.Create(ParticleImageId.MoneyCollection1, position, transform, Target);

      Destroy(playerMoneyParticle.gameObject, 10f);

      return playerMoneyParticle;
    }

    private void PlayBarParticle()
    {
      ParticleImage.gameObject.SetActive(true);
      ParticleImage.Play();
      BounceEffect.ApplyBounceEffect();
    }
  }
}