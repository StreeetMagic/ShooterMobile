using System.Collections;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
  public PlayerHealth PlayerHealth;
  public PlayerTargetHolder PlayerTargetHolder;
  public PlayerTargetLocator PlayerTargetLocator;

  public override void InstallBindings()
  {
    Container.BindInstance(PlayerHealth);

    Container.Bind<PlayerTargetHolder>().FromInstance(PlayerTargetHolder).AsSingle();
    Container.Bind<PlayerTargetLocator>().FromInstance(PlayerTargetLocator).AsSingle();
  }
}