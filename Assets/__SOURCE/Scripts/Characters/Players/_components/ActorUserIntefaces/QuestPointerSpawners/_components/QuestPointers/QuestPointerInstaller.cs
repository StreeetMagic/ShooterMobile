using Quests;
using Zenject;
using Zenject.Source.Install;

namespace Characters.Players._components.ActorUserIntefaces.QuestPointerSpawners._components.QuestPointers
{
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
}