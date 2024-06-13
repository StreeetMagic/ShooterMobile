using System.Collections.Generic;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.TargetLocators
{
  public class PlayerTargetLocator : ITickable
  {
    private const int MaxTargets = 20;

    private readonly PlayerTargetHolder _playerTargetHolder;
    private readonly Transform _transform;
    private readonly IStaticDataService _staticDataService;
    private readonly PlayerWeaponIdProvider _playerWeaponIdProvider;
      
    private readonly Collider[] _colliders = new Collider[MaxTargets];

    public PlayerTargetLocator(PlayerTargetHolder playerTargetHolder, Transform transform, 
      IStaticDataService staticDataService, PlayerWeaponIdProvider playerWeaponIdProvider)
    {
      _playerTargetHolder = playerTargetHolder;
      _transform = transform;
      _staticDataService = staticDataService;
      _playerWeaponIdProvider = playerWeaponIdProvider;
    }

    private float Radius => _staticDataService.GetWeaponConfig(_playerWeaponIdProvider.WeaponTypeId).FireRange; 

    public void Tick()
    {
      int count = Physics.OverlapSphereNonAlloc(_transform.position, Radius, _colliders);

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