using Configs.Resources.QuestConfigs.SubQuestConfigs;
using Quests;

namespace DataRepositories.Quests
{
  public class SubQuest
  {
    public SubQuestConfig Config;
    public int CompletedQuantity;
    public QuestState State;

    public SubQuest(SubQuestConfig config, int completedQuantity, QuestState state)
    {
      Config = config;
      CompletedQuantity = completedQuantity;
      State = state;
    }
  }
}