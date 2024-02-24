using Infrastructure.Services.StateMachines;
using Infrastructure.Services.StateMachines.GameLoopStateMachines.States;
using Zenject;

namespace Infrastructure.DIC.GameLoopSceneContext
{
  public class GameLoopSceneInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindGameLoopStateMachine();
      BindPlayerFactory();
    }

    private void BindPlayerFactory() =>
      Container
        .Bind<PlayerFactory>()
        .AsSingle();

    private void BindGameLoopStateMachine() =>
      Container
        .Bind<IStateMachine<IGameLoopState>>()
        .To<StateMachine<IGameLoopState>>()
        .AsSingle();
  }
}