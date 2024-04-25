using Gameplay.Characters.Players._components.Animators;
using Gameplay.Characters.Players._components.InputHandlers;
using Gameplay.Characters.Players._components.Movers;
using Gameplay.Characters.Players._components.Rotators;
using Gameplay.Characters.Players._components.Shooters;
using Gameplay.Characters.Players._components.TargetHolders;
using Gameplay.Characters.Players._components.TargetLocators;

namespace Gameplay.Characters.Players._components.Factories
{
  public class PlayerProvider
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
  }
}