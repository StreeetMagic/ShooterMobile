using System.Collections;
using System.Collections.Generic;
using Configs.Resources.QuestConfigs.SubQuestConfigs;
using DataRepositories.Quests;
using UnityEngine;

public class SubQuestSlot : MonoBehaviour
{
  public SubQuestConfig Config { get; set; }
  public SubQuest SubQuest { get; set; }
}