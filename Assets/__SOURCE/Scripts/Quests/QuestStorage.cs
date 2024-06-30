using System.Collections.Generic;
using System.Linq;
using Gameplay.Quests.Subquests;
using Infrastructure.ArtConfigServices;
using Infrastructure.ConfigProviders;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories.ProjectContext;

namespace Gameplay.Quests
{
  public class QuestStorage : IProgressWriter
  {
    private Dictionary<QuestId, Quest> _quests;

    private readonly ConfigProvider _configProvider;
    private readonly ProjectZenjectFactory _gameLoopZenjectFactory;
    private readonly ArtConfigProvider _artConfigProvider;

    public QuestStorage(ConfigProvider configProvider,
      ProjectZenjectFactory gameLoopZenjectFactory, ArtConfigProvider artConfigProvider)
    {
      _configProvider = configProvider;
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
      _artConfigProvider = artConfigProvider;
    }

    public Quest GetQuest(QuestId questId)
      => _quests[questId];

    public List<Quest> GetAllQuests()
      => _quests.Values.ToList();

    public void ReadProgress(ProjectProgress projectProgress)
    {
      Dictionary<QuestId, QuestConfig> configs = _configProvider.QuestConfigs;

      _quests = new Dictionary<QuestId, Quest>();

      for (int i = 0; i < projectProgress.Quests.Count; i++) 
      {
        List<SubQuest> subQuests = SubQuest(configs[projectProgress.Quests[i].Id], projectProgress);

        QuestState questState = QuestState(projectProgress, projectProgress.Quests[i].Id);

        var quest = _gameLoopZenjectFactory.InstantiateNative<Quest>(questState, configs[projectProgress.Quests[i].Id], subQuests, i);

        _quests.Add(projectProgress.Quests[i].Id, quest);
      }
    }

    public void WriteProgress(ProjectProgress projectProgress)
    {
      projectProgress.Quests.Clear();

      foreach (KeyValuePair<QuestId, Quest> quest in _quests)
      {
        List<SubQuestProgress> subQuests = new List<SubQuestProgress>();

        foreach (SubQuest subQuest in quest.Value.SubQuests)
        {
          subQuests.Add(new SubQuestProgress(subQuest.Setup.Id, subQuest.CompletedQuantity.Value, subQuest.State.Value));
        }

        projectProgress.Quests.Add(new QuestProgress(quest.Key, quest.Value.State.Value, subQuests));
      }
    }

    public SubQuest GetActiveSubQuest(QuestId configId)
    {
      Quest quest = _quests[configId];

      return quest
        .SubQuests
        .First(x => x.State.Value == Quests.QuestState.Activated);
    }

    private static QuestState QuestState(ProjectProgress projectProgress, QuestId questId)
    {
      return projectProgress
        .Quests
        .Find(x => x.Id == questId)
        .State;
    }

    private List<SubQuest> SubQuest(QuestConfig questConfig, ProjectProgress projectProgress)
    {
      List<SubQuest> subQuests = new List<SubQuest>();

      for (var i = 0; i < questConfig.SubQuests.Count; i++)
      {
        SubQuestProgress progressSubQuest =
          projectProgress
            .Quests
            .Find(x => x.Id == questConfig.Id)
            .SubQuests[i];

        SubQuestSetup subQuestSetup = questConfig.SubQuests[i];
        SubQuestContentSetup subQuestContentSetup = _artConfigProvider.GetSubQuestContentSetup(subQuestSetup.Id);

        var subQuest =
          _gameLoopZenjectFactory
            .InstantiateNative<SubQuest>(subQuestSetup, progressSubQuest.CompletedQuantity, progressSubQuest.State, i, subQuestContentSetup);

        subQuests.Add(subQuest);
      }

      return subQuests;
    }
  }
}