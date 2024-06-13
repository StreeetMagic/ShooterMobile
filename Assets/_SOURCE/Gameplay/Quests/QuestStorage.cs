using System.Collections.Generic;
using System.Linq;
using Gameplay.Quests.Subquests;
using Infrastructure.ConfigServices;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories;

namespace Gameplay.Quests
{
  public class QuestStorage : IProgressWriter
  {
    private Dictionary<QuestId, Quest> _quests;

    private readonly ConfigService _configService;
    private readonly ProjectZenjectFactory _gameLoopZenjectFactory;

    public QuestStorage(ConfigService configService,
      ProjectZenjectFactory gameLoopZenjectFactory)
    {
      _configService = configService;
      _gameLoopZenjectFactory = gameLoopZenjectFactory;
    }

    public Quest GetQuest(QuestId questId)
      => _quests[questId];

    public List<Quest> GetAllQuests()
      => _quests.Values.ToList();

    public void ReadProgress(ProjectProgress projectProgress)
    {
      Dictionary<QuestId, QuestConfig> configs = _configService.QuestConfigs;

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
          subQuests.Add(new SubQuestProgress(subQuest.Setup.Config.Type, subQuest.CompletedQuantity.Value, subQuest.State.Value));
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

    private List<SubQuest> SubQuest(QuestConfig config, ProjectProgress projectProgress)
    {
      List<SubQuest> subQuests = new List<SubQuest>();

      for (var i = 0; i < config.SubQuests.Count; i++)
      {
        SubQuestProgress progressSubQuest =
          projectProgress
            .Quests
            .Find(x => x.Id == config.Id)
            .SubQuests[i];

        SubQuestSetup setup = config.SubQuests[i];

        var subQuest =
          _gameLoopZenjectFactory
            .InstantiateNative<SubQuest>(setup, progressSubQuest.CompletedQuantity, progressSubQuest.State, i);

        subQuests.Add(subQuest);
      }

      return subQuests;
    }
  }
}