using System.Collections.Generic;
using Characters;
using Infrastructure.VisualEffects.ParticleImages;
using Spawners;
using Spawners.SpawnerFactories;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;
using UserInterface.HeadsUpDisplays._components.BackpackBars;
using Zenject;

namespace UserInterface.HeadsUpDisplays._components.MoneyAttractions
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

        private void OnEnemyDied(IHealth enemyHealth)
        {
            Vector3 position = _camera.WorldToScreenPoint(enemyHealth.transform.position);

            //TODO: Valera ищет как достать эти числа из particleImage
            // ReSharper disable once UnusedVariable
            ParticleImage particleImage = PlayerMoneyParticle(position);

            particleImage.onParticleFinish.AddListener(
                () =>
                {
                    print("Есть контакт");
                    PlayBarParticle();
                });

            // int count = 1;
            // float cooldown = .1f;
            // float duration = 1.7f;
            //
            // for (float i = 0; i < count; i++)
            // {
            //   Invoke(nameof(PlayBarParticle), i * cooldown + duration);
            // }
        }

        private ParticleImage PlayerMoneyParticle(Vector3 position)
        {
            ParticleImage playerMoneyParticle =
                _particleImageFactory.Create(ParticleImageId.MoneyCollection1, position, transform, Target);

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