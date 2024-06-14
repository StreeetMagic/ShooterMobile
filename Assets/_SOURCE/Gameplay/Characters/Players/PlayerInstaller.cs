using System;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.MeshModels;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.TargetLocators;
using Gameplay.Weapons;
using Infrastructure.SaveLoadServices;
using UnityEngine;
using Zenject;
using Zenject.Source.Install;

namespace Gameplay.Characters.Players
{
  public class PlayerInstaller : MonoInstaller, IInitializable, IDisposable
  {
    public Player Player;
    public PlayerAnimator PlayerAnimator;
    public PlayerPetSpawnPointsContainer PetSpawnPointsContainer;

    public PlayerWeaponContainer WeaponContainer;

    [Inject] private SaveLoadService _saveLoadServices;

    public override void InstallBindings()
    {
      Container.Bind<Player>().FromInstance(Player).AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerInstaller>().FromInstance(this).AsSingle().NonLazy();

      Container.Bind<PlayerAnimator>().FromInstance(PlayerAnimator).AsSingle();
      Container.Bind<PlayerPetSpawnPointsContainer>().FromInstance(PetSpawnPointsContainer).AsSingle();
      Container.Bind<CharacterController>().FromInstance(GetComponent<CharacterController>()).AsSingle();

      Container.Bind<Transform>().FromInstance(transform).AsSingle();

      Container.Bind<PlayerWeaponContainer>().FromInstance(WeaponContainer).AsSingle();

      Container.BindInterfacesAndSelfTo<PlayerMover>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerRotator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerRotatorController>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponIdProvider>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerStandsOnSamePosition>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerToTargetAggro>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponRaiser>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerHenSpawner>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerBombDefuser>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerMoveSpeed>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerAttacker>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerTargetHolder>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerTargetLocator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponAttacker>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponSwitcher>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponShootingPoint>().AsSingle().NonLazy();
    }

    public void Initialize()
    {
      _saveLoadServices.ProgressReaders.Add(Container.Resolve<PlayerMover>());
      _saveLoadServices.ProgressReaders.Add(Container.Resolve<PlayerWeaponIdProvider>());
    }

    public void Dispose()
    {
      _saveLoadServices.ProgressReaders.Remove(Container.Resolve<PlayerMover>());
      _saveLoadServices.ProgressReaders.Remove(Container.Resolve<PlayerWeaponIdProvider>());
    }
  }
}