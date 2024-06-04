using Gameplay.Characters.Players.InputHandlers;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.PetSpawnPointsContainers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class PlayerProvider
  {
    public Player Player { get; set; }

    public PlayerMover PlayerMover { get; set; }
    public PlayerRotator PlayerRotator { get; set; }
    public PlayerTargetLocator PlayerTargetLocator { get; set; }
    public PlayerTargetHolder PlayerTargetHolder { get; set; }
    public PlayerHealth PlayerHealth { get; set; }
    public PetSpawnPointsContainer PetSpawnPointsContainer { get; set; }
    public PlayerHenSpawner PlayerHenSpawner { get; set; }

    public PlayerRotatorController PlayerRotatorController { get; set; }
    public PlayerInputHandler PlayerInputHandler { get; set; }
    public WeaponShootingPoint WeaponShootingPointPoint { get; set; }

    public Transform Transform { get; set; }
  }
}