using Characters.Players;
using Infrastructure.ArtConfigServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace Vlad.HeadsUpDisplays.HeadsUpDisplayDebugs.Current
{
  public class CurrentWeaponText : MonoBehaviour
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

      _text.text = _artConfigProvider.GetWeaponContentSetup(_playerProvider.Instance.WeaponIdProvider.CurrentId.Value).Name;
    }
  }
}