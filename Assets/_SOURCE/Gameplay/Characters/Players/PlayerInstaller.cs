using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using Zenject.Source.Install;

namespace Gameplay.Characters.Players
{
  public class PlayerInstaller : MonoInstaller
  {
    public PlayerHealth PlayerHealth;
    public PlayerTargetHolder PlayerTargetHolder;
    public PlayerTargetLocator PlayerTargetLocator;
    public PlayerAnimator PlayerAnimator;

    public override void InstallBindings()
    {
      Container.BindInstance(PlayerHealth);

      Container.Bind<PlayerTargetHolder>().FromInstance(PlayerTargetHolder).AsSingle();
      Container.Bind<PlayerTargetLocator>().FromInstance(PlayerTargetLocator).AsSingle();
      Container.Bind<PlayerAnimator>().FromInstance(PlayerAnimator).AsSingle();
    }
  }
}