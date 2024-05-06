using Configs.Resources.QuestConfigs.Scripts;
using Gameplay.Characters.Players.ActorUserIntefaces.QuestPointerSpawners.QuestPointers;
using Quests;
using Zenject;
using Zenject.Source.Install;

public class QuestPointerInstaller : MonoInstaller
{
  [Inject] private readonly Quest _quest;
  [Inject] private readonly QuestConfig _config;

  public override void InstallBindings()
  {
    Container.Bind<Quest>().FromInstance(_quest);
    Container.Bind<QuestConfig>().FromInstance(_config);
    Container.Bind<QuestPointer>().FromInstance(GetComponent<QuestPointer>()).AsSingle();
  }
}