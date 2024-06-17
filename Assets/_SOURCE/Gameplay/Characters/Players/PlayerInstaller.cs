using System;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.MeshModels;
using Gameplay.Characters.Players.StateMachines;
using Gameplay.Characters.Players.TargetLocators;
using Gameplay.Weapons;
using Infrastructure.SaveLoadServices;
using Infrastructure.ZenjectFactories.GameobjectContext;
using UnityEngine;
using Zenject;
using Zenject.Source.Install;

namespace Gameplay.Characters.Players
{
  public class PlayerInstaller : MonoInstaller, IInitializable, IDisposable
  {
    [SerializeField] private PlayerAnimator PlayerAnimator;
    [SerializeField] private PlayerPetSpawnPointsContainer _petSpawnPointsContainer;
    [SerializeField] private PlayerWeaponContainer WeaponContainer;

    [Inject] private SaveLoadService _saveLoadServices;

    public Transform Transform { get; private set; }
    public PlayerWeaponShootingPoint WeaponShootingPointPoint { get; private set; }
    public PlayerTargetHolder TargetHolder { get; private set; }
    public PlayerHealth Health { get; private set; }
    public PlayerHenSpawner HenSpawner { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerStandsOnSamePosition StandsOnSamePosition { get; private set; }
    public PlayerPetSpawnPointsContainer PetSpawnPointsContainer { get; private set; }
    public PlayerWeaponIdProvider WeaponIdProvider { get; private set; }
    public PlayerBombDefuser BombDefuser { get; private set; }
    public PlayerMoveSpeed MoveSpeed { get; private set; }
    public PlayerWeaponAmmo WeaponAmmo { get; private set; }
    public PlayerMover Mover { get; private set; }
    public WeaponStorage WeaponStorage { get; private set; }

    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<PlayerInstaller>().FromInstance(this).AsSingle().NonLazy();

      Container.Bind<PlayerAnimator>().FromInstance(PlayerAnimator).AsSingle();
      Container.Bind<PlayerPetSpawnPointsContainer>().FromInstance(_petSpawnPointsContainer).AsSingle();
      Container.Bind<CharacterController>().FromInstance(GetComponent<CharacterController>()).AsSingle();

      Container.Bind<Transform>().FromInstance(transform).AsSingle();
      Container.Bind<PlayerWeaponContainer>().FromInstance(WeaponContainer).AsSingle();

      Container.BindInterfacesAndSelfTo<PlayerMover>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerRotator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponIdProvider>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerStandsOnSamePosition>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerToTargetAggro>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponRaiser>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponLowerer>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerHenSpawner>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerBombDefuser>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerMoveSpeed>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerTargetHolder>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerTargetLocator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponAttacker>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponMeshSwitcher>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponShootingPoint>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerZenjectFactory>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerFiniteStateMachine>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponAmmo>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponMagazineReloader>().AsSingle().NonLazy();

      Transform = Container.Resolve<Transform>();
      WeaponShootingPointPoint = Container.Resolve<PlayerWeaponShootingPoint>();
      TargetHolder = Container.Resolve<PlayerTargetHolder>();
      Health = Container.Resolve<PlayerHealth>();
      HenSpawner = Container.Resolve<PlayerHenSpawner>();
      InputHandler = Container.Resolve<PlayerInputHandler>();
      StandsOnSamePosition = Container.Resolve<PlayerStandsOnSamePosition>();
      PetSpawnPointsContainer = Container.Resolve<PlayerPetSpawnPointsContainer>();
      WeaponIdProvider = Container.Resolve<PlayerWeaponIdProvider>();
      BombDefuser = Container.Resolve<PlayerBombDefuser>();
      Mover = Container.Resolve<PlayerMover>();
      WeaponStorage = Container.Resolve<WeaponStorage>();
      MoveSpeed = Container.Resolve<PlayerMoveSpeed>();
      WeaponAmmo = Container.Resolve<PlayerWeaponAmmo>();
    }

    public void Initialize()
    {
      _saveLoadServices.ProgressReaders.Add(Mover);
      _saveLoadServices.ProgressReaders.Add(WeaponIdProvider);
      _saveLoadServices.ProgressReaders.Add(WeaponStorage);
    }

    public void Dispose()
    {
      _saveLoadServices.ProgressReaders.Remove(Mover);
      _saveLoadServices.ProgressReaders.Remove(WeaponIdProvider);
      _saveLoadServices.ProgressReaders.Remove(WeaponStorage);
    }
  }
}