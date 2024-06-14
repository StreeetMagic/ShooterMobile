using Gameplay.Weapons;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class Player : MonoBehaviour
  {
    [Inject] public Transform Transform { get; }
    
    [Inject] public PlayerWeaponShootingPoint WeaponShootingPointPoint { get; }
    
    [Inject] public PlayerTargetHolder TargetHolder { get; }
    [Inject] public PlayerHealth Health { get; }
    [Inject] public PlayerHenSpawner HenSpawner { get; }
    [Inject] public PlayerInputHandler InputHandler { get; }
    [Inject] public PlayerStandsOnSamePosition StandsOnSamePosition { get; }
    [Inject] public PlayerPetSpawnPointsContainer PetSpawnPointsContainer { get; }
    [Inject] public PlayerWeaponIdProvider WeaponIdProvider { get; }
    [Inject] public PlayerBombDefuser BombDefuser { get; }
  }
}
