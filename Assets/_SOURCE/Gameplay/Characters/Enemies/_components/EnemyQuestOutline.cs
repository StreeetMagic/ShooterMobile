using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using Quests;
using Quests.Subquests;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyQuestOutline : MonoBehaviour
  {
    public GameObject Outline;

    private QuestStorage _storage;

    [Inject]
    private void Construct(QuestStorage storage, Enemy enemy)
    {
      _storage = storage;
    }

    private void OnEnable()
    {
      Outline.SetActive(false);
    }

    private void Update()
    {
      Outline.SetActive(HasActiveSubQuest());
    }

    private bool HasActiveSubQuest()
    {
      foreach (Quest quest in _storage.GetAllQuests())
      {
        foreach (SubQuest subQuest in quest.SubQuests)
        {
          if (subQuest.State.Value == QuestState.Activated)
          {
            if (subQuest.Setup.Config.Type == SubQuestType.KillOrinaryPersons)
            {
              return true;
            }
          }
        }
      }

      return false;
    }
  }
}