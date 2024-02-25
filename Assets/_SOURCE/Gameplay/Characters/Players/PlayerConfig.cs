using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
  [field: SerializeField] public float MoveSpeed { get; private set; }
  [field: SerializeField] public float RotationSpeed { get; private set; }
}