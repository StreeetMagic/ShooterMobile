using Quests;
using UnityEngine;
using Zenject.Source.Factories;

namespace Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners._components.QuestPointers
{
  public class QuestPointer : MonoBehaviour
  {
    public class Factory : PlaceholderFactory<Quest, QuestConfig, QuestPointer>
    {
    }
  }
}