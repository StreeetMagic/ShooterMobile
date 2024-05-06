using Gameplay.Characters.Pets.Hens;
using UnityEngine;
using Zenject;

public class PlayerHenSpawner : MonoBehaviour
{
  [Inject] private HenSpawner _henSpawner;

  private float _coolDownTimer;

  private readonly float _coolDown = 2f;

  private void Start()
  {
    _coolDownTimer = _coolDown;
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
        _coolDownTimer = _coolDown;

        _henSpawner.Spawn();
      }
    }
  }
}