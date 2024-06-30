using Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners._components.QuestPointers;
using Quests;
using UnityEngine;
using Zenject;

namespace Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners
{
  public class QuestPointerSpawner : MonoBehaviour
  {
    [Inject] private QuestPointer.Factory _pointerFactory;
    [Inject] private QuestStorage _questsStorage;

    private void Start()
    {
      foreach (Quest quest in _questsStorage.GetAllQuests())
      {
        QuestPointer questPointer = _pointerFactory.Create(quest, quest.Config);
        questPointer.transform.SetParent(transform);
        questPointer.transform.localPosition = Vector3.zero;
      }
    }
  }
}