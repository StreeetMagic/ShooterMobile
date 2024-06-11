using Gameplay.Characters.Players.PetSpawnPointsContainers;
using Gameplay.Weapons;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class Player : MonoBehaviour
  {
    [Inject] public PlayerTargetHolder TargetHolder { get; }
    [Inject] public PlayerHealth Health { get; }
    [Inject] public WeaponShootingPoint WeaponShootingPointPoint { get; }
    [Inject] public PlayerHenSpawner HenSpawner { get; }
    [Inject] public PlayerInputHandler InputHandler { get; }
    [Inject] public PlayerStandsOnSamePosition StandsOnSamePosition { get; }
    [Inject] public PlayerPetSpawnPointsContainer PetSpawnPointsContainer { get; }
    [Inject] public Transform Transform { get; }
    [Inject] public PlayerWeaponIdProvider WeaponIdProvider { get; }
  }
}
