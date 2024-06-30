using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Characters.Enemies.Configs
{
  [Serializable]
  public class EnemyTypeVisualEffectsSetup
  {
    public EnemyTypeId EnemyId;
    public EnemyVisualEffectsSetupId VisualEffectsSetupId; 
    public EnemyMeshModel EnemyMeshModelPrefab;
  }
}