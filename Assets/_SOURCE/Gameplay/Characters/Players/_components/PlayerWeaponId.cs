using System;
using Projects;
using SaveLoadServices;
using StaticDataServices;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerWeaponId : MonoBehaviour, IProgressWriter
  {
    [Inject] private IStaticDataService _staticDataService;

    private void Awake()
    {
      WeaponTypeId = _staticDataService.GetPlayerConfig().StartWeapon;
    }

    public WeaponTypeId WeaponTypeId { get; set; } = WeaponTypeId.Unknown;

    public void ReadProgress(ProjectProgress projectProgress)
    {
      WeaponTypeId = projectProgress.PlayerWeaponId;
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.PlayerWeaponId = WeaponTypeId;
    }
  }
}