using System.Collections.Generic;
using Configs.Resources.QuestConfigs.SubQuestConfigs.Scripts;
using Gameplay.Bombs;
using Gameplay.Characters.Players.Factories;
using Quests;
using UnityEngine;
using Zenject;

public class BombDestroer : MonoBehaviour
{
  public BombDefuser BombDefuser;

  [Inject] private PlayerProvider _playerProvider;
  [Inject] private QuestStorage _storage;

  private void OnEnable()
  {
    BombDefuser.Defused += OnDefused;
  }

  private void OnDisable()
  {
    BombDefuser.Defused -= OnDefused;
  }

  private void OnDefused(BombDefuser defuser)
  {
    PlayerBombDefuser playerBombDefuser = _playerProvider.Player.GetComponent<PlayerBombDefuser>();

    if (playerBombDefuser.Bombs.Contains(defuser.GetComponent<Bomb>()))
    {
      playerBombDefuser.Bombs.Remove(defuser.GetComponent<Bomb>());
    }

    List<Quest> allQuests = _storage.GetAllQuests();

    foreach (var quest in allQuests)
    {
      if (quest.State.Value == QuestState.Activated)
      {
        foreach (var subQuest in quest.SubQuests)
        {
          if (subQuest.State.Value == QuestState.Activated)
          {
            if (subQuest.Setup.Config.Type == SubQuestType.DefuseBomb)
            {
              subQuest.CompletedQuantity.Value++;
            }
          }
        }
      }
    }
  }
}