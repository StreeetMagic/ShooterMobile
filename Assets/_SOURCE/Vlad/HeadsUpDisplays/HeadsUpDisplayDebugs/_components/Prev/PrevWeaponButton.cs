using Gameplay.Characters.Players;
using Gameplay.Weapons;
using Infrastructure.ArtConfigServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Prev
{
  public class PrevWeaponButton : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigService _artConfigService;

    private Button _button;

    private void Awake()
    {
      _button = GetComponent<Button>();
    }

    private void Update()
    {
      WeaponTypeId weaponTypeId = _playerProvider.Instance.WeaponIdProvider.PrevId.Value;

      if (weaponTypeId == WeaponTypeId.Unknown)
        _button.onClick.RemoveAllListeners();
      else
        _button.onClick.AddListener(() => _playerProvider.Instance.WeaponIdProvider.CurrentId.Value = weaponTypeId);
    }
  }
}