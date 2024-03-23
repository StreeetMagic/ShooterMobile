using System;
using Gameplay.Characters.Enemies.Spawners.DebugServices;
using Infrastructure.Games;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.GameStateMachines.States;
using Inputs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RestartGameButton : MonoBehaviour
{
  public Button Button;

  private DebugService _debugService;

  [Inject]
  private void Construct( DebugService debugService)
  {
    _debugService = debugService;
  }

  private void Start()
  {
    Button.onClick.AddListener(RestartGame);
  }

  private void RestartGame()
  {
    _debugService.Restart();
  }
}