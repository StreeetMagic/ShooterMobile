using Infrastructure.Games;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RestartGameButton : MonoBehaviour
{
  public Button Button;

  private IStateMachine<IGameState> _gameStateMachine;

  [Inject]
  private void Construct(IStateMachine<IGameState> gameStateMachine)
  {
    _gameStateMachine = gameStateMachine;
  }

  private void Start()
  {
    Button.onClick.AddListener(RestartGame);
  }

  private void RestartGame()
  {
    _gameStateMachine.Enter<LoadLevelState, string>(Constants.Scenes.GameLoop);
  }
}