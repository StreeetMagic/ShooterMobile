using Configs.Resources.QuestConfigs.Scripts;
using Gameplay.Characters.Players._components.Factories;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace Gameplay.Characters.Questers._components
{
  public class OpenQuestButtonEnabler : MonoBehaviour
  {
    public const float Distance = 4;

    public QuestId QuestId;
    public bool IsActive;

    private PlayerProvider _playerProvider;
    private HeadsUpDisplayProvider _headsUpDisplayProvider;

    [Inject]
    private void Construct(PlayerProvider playerProvider, HeadsUpDisplayProvider headsUpDisplayProvider)
    {
      if (QuestId == QuestId.Unknown)
        throw new System.Exception("Unknown quest id");

      _playerProvider = playerProvider;
      _headsUpDisplayProvider = headsUpDisplayProvider;
    }

    private void Update()
    {
      float distance = Vector3.Distance(transform.position, _playerProvider.Player.transform.position);

      if (distance < Distance)
      {
        IsActive = true;
        _headsUpDisplayProvider.OpenQuestButton.QuestId = QuestId;
      }
      else
      {
        IsActive = false;
      }
    }
  }
}