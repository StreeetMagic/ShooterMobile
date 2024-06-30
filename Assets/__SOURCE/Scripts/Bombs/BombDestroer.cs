using System.Collections.Generic;
using Characters.Players;
using Characters.Players._components;
using Quests;
using Quests.Subquests;
using UnityEngine;
using Zenject;

namespace Bombs
{
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
      PlayerBombDefuser playerBombDefuser = _playerProvider.Instance.BombDefuser;

      if (playerBombDefuser.Bombs.Contains(defuser.Bomb))
      {
        playerBombDefuser.Bombs.Remove(defuser.Bomb);
      }

      List<Quest> allQuests = _storage.GetAllQuests();

      foreach (Quest quest in allQuests)
      {
        if (quest.State.Value == QuestState.Activated)
        {
          foreach (SubQuest subQuest in quest.SubQuests)
          {
            if (subQuest.State.Value == QuestState.Activated)
            {
              if (subQuest.ContentSetup.Id == SubQuestId.DefuseBomb)
              {
                subQuest.CompletedQuantity.Value++;
              }
            }
          }
        }
      }
    }
  }
}