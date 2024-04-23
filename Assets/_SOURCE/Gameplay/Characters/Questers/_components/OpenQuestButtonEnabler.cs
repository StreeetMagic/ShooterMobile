using Gameplay.Characters.Players.Factories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

public class OpenQuestButtonEnabler : MonoBehaviour
{
  private PlayerProvider _playerProvider;
  private HeadsUpDisplayProvider _headsUpDisplayProvider;

  [Inject]
  private void Construct(PlayerProvider playerProvider, HeadsUpDisplayProvider headsUpDisplayProvider)
  {
    _playerProvider = playerProvider;
    _headsUpDisplayProvider = headsUpDisplayProvider;
  }

  private void Update()
  {
    float distance = Vector3.Distance(transform.position, _playerProvider.Player.transform.position);

    _headsUpDisplayProvider.HeadsUpDisplay.OpenQuestButton.gameObject.SetActive(distance < 3);
  }
}