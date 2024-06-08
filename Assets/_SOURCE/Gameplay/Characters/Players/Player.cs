using Gameplay.Characters.Players.PetSpawnPointsContainers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Weapons;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class Player : MonoBehaviour
  {
    [Inject] public PlayerTargetHolder TargetHolder { get; }
    [Inject] public PlayerRotator Rotator { get; }
    [Inject] public PlayerHealth Health { get; }
    [Inject] public WeaponShootingPoint WeaponShootingPointPoint { get; }
    [Inject] public PlayerHenSpawner HenSpawner { get; }
    [Inject] public PlayerInputHandler InputHandler { get; }
    [Inject] public PlayerStandsOnSamePosition PlayerStandsOnSamePosition { get; }
    [Inject] public PetSpawnPointsContainer PetSpawnPointsContainer { get; }
    [Inject] public PlayerRotatorController RotatorController { get; }
    [Inject] public PlayerMover Mover { get; }
    [Inject] public Transform Transform { get; }
  }
}