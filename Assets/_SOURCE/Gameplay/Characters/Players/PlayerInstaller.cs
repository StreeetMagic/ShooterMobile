using System.Collections;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Players;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
  public PlayerHealth PlayerHealth;

  public override void InstallBindings()
  {
    Container.BindInstance(PlayerHealth);
  }
}