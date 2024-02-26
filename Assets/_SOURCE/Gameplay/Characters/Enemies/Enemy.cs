using System.Collections;
using System.Collections.Generic;
using _SOURCE.Gameplay.Characters.Enemies;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [field: SerializeField] public EnemyId Id { get; private set; }
}