using Gameplay.Characters.Pets.Hens;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerHenSpawner : MonoBehaviour
  {
    private const float CoolDown = 2f;

    private float _coolDownTimer;

    [Inject] private readonly HenSpawner _henSpawner;

    public int Count { get; set; }

    private void Start()
    {
      _coolDownTimer = CoolDown;
      Count = 0;
    }

    private void Update()
    {
      if (_henSpawner.Count == 0)
      {
        if (_coolDownTimer > 0)
        {
          _coolDownTimer -= Time.deltaTime;
        }
        else
        {
          if (Count > 0)
          {
            Count--;
            _coolDownTimer = CoolDown;

            _henSpawner.Spawn();
          }
        }
      }
    }
  }
}