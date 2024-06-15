using System.Collections.Generic;
using Infrastructure.ConfigServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : ITickable
  {
    private const int MaxTargets = 20;

    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly Transform _transform;
    private readonly ConfigService _configService;
    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;
      
    private readonly Collider[] _colliders = new Collider[MaxTargets];

    public PlayerTargetLocator(PlayerTargetHolder playerTargetHolder, Transform transform, 
      ConfigService configService, PlayerWeaponIdProvider playerWeaponIdProvider)
    {
      _playerTargetHolder = playerTargetHolder;
      _transform = transform;
      _configService = configService;
      _playerWeaponIdProvider = playerWeaponIdProvider;
    }

    public void Tick()
    {
      int count = Physics.OverlapSphereNonAlloc(_transform.position, _configService.GetWeaponConfig(_playerWeaponIdProvider.Id).FireRange, _colliders);

      var list = new List<ITargetTrigger>();

      for (var index = 0; index < count; index++)
      {
        Collider collider1 = _colliders[index];

        if (collider1.gameObject.TryGetComponent(out ITargetTrigger targetTrigger) == false)
          continue;

        if (targetTrigger.Health.IsDead)
          continue;

        list.Add(targetTrigger);
      }

      _playerTargetHolder.AddTargets(list);
    }
  }
}