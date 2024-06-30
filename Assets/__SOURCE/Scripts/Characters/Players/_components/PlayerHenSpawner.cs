using Gameplay.Characters.Pets.Hens;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerHenSpawner : ITickable
  {
    private const float CoolDown = 2f;

    private readonly HenSpawner _henSpawner;

    private float _coolDownTimer;

    public PlayerHenSpawner(HenSpawner henSpawner)
    {
      _henSpawner = henSpawner;

      _coolDownTimer = CoolDown;
      Count = 0;
    }

    public int Count { get; set; }

    public void Tick()
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