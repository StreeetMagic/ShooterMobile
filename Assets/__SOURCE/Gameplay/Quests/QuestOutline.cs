using Gameplay.Quests.Subquests;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay.Quests
{
  public class QuestOutline : MonoBehaviour
  {
    [FormerlySerializedAs("subQuestTypeId")] [FormerlySerializedAs("SubQuestType")] public SubQuestId subQuestId;
    public GameObject Outline;

    private QuestStorage _storage;

    [Inject]
    private void Construct(QuestStorage storage)
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
          if (subQuest.State.Value != QuestState.Activated)
            continue;

          if (subQuest.ContentSetup.Id == subQuestId)
          {
            return true;
          }
        }
      }

      return false;
    }
  }
}