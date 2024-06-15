using Gameplay.Characters.Players;
using Gameplay.Weapons;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs._components.Next
{
  public class NextWeaponIcon : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigService _artConfigService;

    private Image _icon;

    private void Awake()
    {
      _icon = GetComponent<Image>();
    }

    private void Update()
    {
      WeaponTypeId weaponTypeId = _playerProvider.Instance.WeaponIdProvider.NextId.Value;

      if (weaponTypeId == WeaponTypeId.Unknown)
        _icon.sprite = null;
      else
        _icon.sprite = _artConfigService.GetWeaponContentSetup(weaponTypeId).Icon;
    }
  }
}