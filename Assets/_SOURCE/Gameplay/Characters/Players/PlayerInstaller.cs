using System;
using Gameplay.Characters.Players.Animators;
using Gameplay.Characters.Players.PetSpawnPointsContainers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.Shooters;
using Gameplay.Characters.Players.TargetLocators;
using Gameplay.Weapons;
using SaveLoadServices;
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

    public WeaponContainer WeaponContainer;
    public WeaponSwitcher WeaponSwitcher;
    public Weapon Weapon;
    public WeaponShootingPoint WeaponShootingPoint;
    public WeaponAttacker WeaponAttacker;

    [Inject] private SaveLoadService _saveLoadServices;

    public override void InstallBindings()
    {
      Container.Bind<Player>().FromInstance(Player).AsSingle();
      Container.BindInterfacesAndSelfTo<PlayerInstaller>().FromInstance(this).AsSingle().NonLazy();

      Container.Bind<PlayerAnimator>().FromInstance(PlayerAnimator).AsSingle();
      Container.Bind<PlayerPetSpawnPointsContainer>().FromInstance(PetSpawnPointsContainer).AsSingle();
      Container.Bind<CharacterController>().FromInstance(GetComponent<CharacterController>()).AsSingle();

      Container.Bind<Transform>().FromInstance(transform).AsSingle();

      Container.Bind<WeaponContainer>().FromInstance(WeaponContainer).AsSingle();
      Container.Bind<WeaponSwitcher>().FromInstance(WeaponSwitcher).AsSingle();
      Container.Bind<Weapon>().FromInstance(Weapon).AsSingle();
      Container.Bind<WeaponAttacker>().FromInstance(WeaponAttacker).AsSingle();
      Container.Bind<WeaponShootingPoint>().FromInstance(WeaponShootingPoint).AsSingle();

      Container.BindInterfacesAndSelfTo<PlayerMover>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerRotator>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerRotatorController>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<PlayerWeaponId>().AsSingle().NonLazy();
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
    }

    public void Initialize()
    {
      _saveLoadServices.ProgressReaders.Add(Container.Resolve<PlayerMover>());
      _saveLoadServices.ProgressReaders.Add(Container.Resolve<PlayerWeaponId>());
    }

    public void Dispose()
    {
      _saveLoadServices.ProgressReaders.Remove(Container.Resolve<PlayerMover>());
      _saveLoadServices.ProgressReaders.Remove(Container.Resolve<PlayerWeaponId>());
    }
  }
}