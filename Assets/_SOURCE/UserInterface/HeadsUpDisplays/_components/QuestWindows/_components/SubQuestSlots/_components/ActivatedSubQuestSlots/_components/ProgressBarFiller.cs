using Configs.Resources.QuestConfigs.Scripts;
using Quests.Subquests;
using UnityEngine;
using Zenject;

public class ProgressBarFiller : MonoBehaviour
{
  public RectTransform RectTransform;

  [Inject] private SubQuest _subQuest;
  [Inject] private SubQuestSetup _setup;
}