using Characters.Players;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Weapons;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Prev
{
  public class PrevWeaponIcon : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigProvider _artConfigProvider;

    private Image _icon;

    private void Awake()
    {
      _icon = GetComponent<Image>();
    }

    private void Update()
    {
      if (!_playerProvider.Instance)
        return;
      
      WeaponTypeId weaponTypeId = _playerProvider.Instance.WeaponIdProvider.PrevId.Value;

      if (weaponTypeId == WeaponTypeId.Unknown)
        _icon.sprite = null;
      else
        _icon.sprite = _artConfigProvider.GetWeaponContentSetup(weaponTypeId).Icon;
    }
  }
}