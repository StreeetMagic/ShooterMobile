using Infrastructure.Services.StateMachines;
using Infrastructure.Services.StateMachines.GameLoopStateMachines.States;
using Zenject;

namespace Infrastructure.DIC.GameLoopSceneContext
{
  public class GameLoopSceneInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      BindPlayerFactory();
    }

    private void BindPlayerFactory() =>
      Container
        .Bind<PlayerFactory>()
        .AsSingle();
  }
}