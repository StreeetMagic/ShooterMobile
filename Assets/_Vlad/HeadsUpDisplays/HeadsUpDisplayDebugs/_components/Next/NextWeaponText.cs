using Characters.Players;
using Infrastructure.ArtConfigServices;
using TMPro;
using UnityEngine;
using Weapons;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Next
{
  public class NextWeaponText : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigProvider _artConfigProvider;

    private TextMeshProUGUI _text;

    private void Awake()
    {
      _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      if (!_playerProvider.Instance)
        return;
      
      WeaponTypeId weaponTypeId = _playerProvider.Instance.WeaponIdProvider.NextId.Value;

      if (weaponTypeId == WeaponTypeId.Unknown)
        _text.text = "";
      else
        _text.text = _artConfigProvider.GetWeaponContentSetup(weaponTypeId).Name;
    }
  }
}