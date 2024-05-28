using Gameplay.Quests;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.HeadsUpDisplays.Windows.QuestWindows._components
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