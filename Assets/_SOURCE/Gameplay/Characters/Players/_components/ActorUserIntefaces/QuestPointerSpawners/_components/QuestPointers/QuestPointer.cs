using Configs.Resources.QuestConfigs.Scripts;
using Quests;
using UnityEngine;
using Zenject.Source.Factories;

namespace Gameplay.Characters.Players.ActorUserIntefaces.QuestPointerSpawners.QuestPointers
{
  public class QuestPointer : MonoBehaviour
  {
    public class Factory : PlaceholderFactory<Quest, QuestConfig, QuestPointer>
    {
    }
  }
}