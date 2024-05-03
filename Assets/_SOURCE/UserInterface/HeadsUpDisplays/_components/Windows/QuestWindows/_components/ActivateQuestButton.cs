using Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.QuestWindows
{
  public class ActivateQuestButton : MonoBehaviour
  {
    public Button Button;
    public QuestWindow QuestWindow;

    [Inject] private Quest _quest;

    private void Start()
    {
      Button.onClick.AddListener(Activate);
    }

    private void Activate()
    {
      _quest.State.Value = QuestState.Activated;
    }
  }
}