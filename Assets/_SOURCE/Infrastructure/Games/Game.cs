using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Infrastructure.ZenjectFactories;

namespace Infrastructure.Games
{
  public class Game
  {
    private readonly IStateMachine<IGameState> _gameStateMachine;
    private readonly IZenjectFactory _factory;

    public Game
    (
      IStateMachine<IGameState> gameStateMachine,
      IZenjectFactory factory
    )
    {
      _gameStateMachine = gameStateMachine;
      _factory = factory;
    }

    public void Start()
    {
      RegisterGameStateMachineStates();

      _gameStateMachine.Enter<BootstrapState>();
    }

    private void RegisterGameStateMachineStates()
    {
      _gameStateMachine.Register(_factory.Create<BootstrapState>());
      _gameStateMachine.Register(_factory.Create<LoadLevelState>());
    }
  }
}