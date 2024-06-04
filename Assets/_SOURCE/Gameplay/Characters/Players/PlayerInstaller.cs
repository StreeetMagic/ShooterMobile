using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.PetSpawnPointsContainers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using Gameplay.Weapons;
using SaveLoadServices;
using UnityEngine;
using Zenject;
using Zenject.Source.Install;

namespace Gameplay.Characters.Players
{
  public class PlayerInstaller : MonoInstaller
  {
    public PlayerHealth PlayerHealth;
    public PlayerTargetHolder PlayerTargetHolder;
    public PlayerTargetLocator PlayerTargetLocator;
    public PlayerAnimator PlayerAnimator;
    public PlayerMoveSpeed PlayerMoveSpeed;
    public PetSpawnPointsContainer PetSpawnPointsContainer;
    public PlayerWeaponRaiser PlayerWeaponRaiser;

    public WeaponContainer WeaponContainer;
    public WeaponSwitcher WeaponSwitcher;
    public Weapon Weapon;
    public WeaponShootingPoint WeaponShootingPoint;

    [Inject] private PlayerProvider _playerProvider;
    [Inject] private SaveLoadService _saveLoadServices;

    public override void InstallBindings()
    {
      Container.Bind<Transform>().FromInstance(transform).AsSingle();
      Container.BindInstance(PlayerHealth);

      Container.Bind<PlayerTargetHolder>().FromInstance(PlayerTargetHolder).AsSingle();
      Container.Bind<PlayerTargetLocator>().FromInstance(PlayerTargetLocator).AsSingle();
      Container.Bind<PlayerAnimator>().FromInstance(PlayerAnimator).AsSingle();
      Container.Bind<PlayerMoveSpeed>().FromInstance(PlayerMoveSpeed).AsSingle();
      Container.Bind<PetSpawnPointsContainer>().FromInstance(PetSpawnPointsContainer).AsSingle();
      Container.Bind<CharacterController>().FromInstance(GetComponent<CharacterController>()).AsSingle();
      Container.Bind<PlayerWeaponRaiser>().FromInstance(PlayerWeaponRaiser).AsSingle();

      Container.Bind<WeaponContainer>().FromInstance(WeaponContainer).AsSingle();
      Container.Bind<WeaponSwitcher>().FromInstance(WeaponSwitcher).AsSingle();
      Container.Bind<Weapon>().FromInstance(Weapon).AsSingle();
      Container.Bind<WeaponShootingPoint>().FromInstance(WeaponShootingPoint).AsSingle();

      Container.Bind<PlayerMover>().AsSingle().NonLazy();
      _playerProvider.PlayerMover = Container.Resolve<PlayerMover>();
      _saveLoadServices.ProgressReaders.Add(Container.Resolve<PlayerMover>());

      Container.Bind<PlayerRotator>().AsSingle().NonLazy();
      _playerProvider.PlayerRotator = Container.Resolve<PlayerRotator>();
    }
  }
}