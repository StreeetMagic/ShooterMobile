using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.InputHandlers;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.Shooters;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Factories
{
  public class PlayerProvider : ITickable
  {
    public Player Player { get; set; }

    public PlayerMover PlayerMover { get; set; }
    public PlayerRotator PlayerRotator { get; set; }
    public PlayerTargetLocator PlayerTargetLocator { get; set; }

    public PlayerTargetHolder PlayerTargetHolder { get; set; }
    public PlayerRotatorController PlayerRotatorController { get; set; }
    public PlayerInputHandler PlayerInputHandler { get; set; }
    public PlayerShooter PlayerShooter { get; set; }
    public PlayerAnimator PlayerAnimator { get; set; }
    public PlayerAnimatorEventHandler PlayerAnimatorEventHandler { get; set; }

    public void Tick()
    {
      var playerInputHandler = PlayerInputHandler as ITickable;
      playerInputHandler.Tick();
      
      var playerTargetHolder = PlayerTargetHolder as ITickable;
      playerTargetHolder.Tick();
      
      var playerShooter = PlayerShooter as ITickable;
      playerShooter.Tick();
    }
  }
}