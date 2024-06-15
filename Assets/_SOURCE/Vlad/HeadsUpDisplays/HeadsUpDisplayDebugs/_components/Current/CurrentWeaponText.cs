using Gameplay.Characters.Players;
using Infrastructure.ArtConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Current
{
  public class CurrentWeaponText : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private ArtConfigService _artConfigService;

    private TextMeshProUGUI _text;

    private void Awake()
    {
      _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
      _text.text = _artConfigService.GetWeaponContentSetup(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Name;
    }
  }
}