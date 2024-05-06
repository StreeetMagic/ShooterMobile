using Configs.Resources.QuestConfigs.Scripts;
using Gameplay.Characters.Players.Factories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace Gameplay.Characters.Questers
{
  public class OpenQuestButtonEnabler : MonoBehaviour
  {
    public const float Distance = 4;

    public QuestId QuestId;
    public bool IsActive;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private HeadsUpDisplayProvider _headsUpDisplayProvider;

    private void OnEnable()
    {
      if (QuestId == QuestId.Unknown)
        throw new System.Exception("Unknown quest id");
    }

    private void Update()
    {
      if (_playerProvider.Player == null)
        return;

      float distance = Vector3.Distance(transform.position, _playerProvider.Player.transform.position);

      if (distance < Distance)
      {
        _headsUpDisplayProvider.OpenQuestButton.QuestId = QuestId;
        IsActive = true;
      }
      else
      {
        IsActive = false;
      }
    }
  }
}