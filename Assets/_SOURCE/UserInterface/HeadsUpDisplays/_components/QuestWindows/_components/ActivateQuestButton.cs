using Quests;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface.HeadsUpDisplays.QuestWindows._components
{
  public class ActivateQuestButton : MonoBehaviour
  {
    public Button Button;
    public QuestWindow QuestWindow;

    private Quest Quest => QuestWindow.Quest;

    private void Start()
    {
      Button.onClick.AddListener(Activate);
    }

    private void Activate()
    {
      Quest.State.Value = QuestState.Activated;
    }
  }
}