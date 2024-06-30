using System;
using Characters.Enemies._components;

namespace Characters.Enemies.Configs
{
  [Serializable]
  public class EnemyTypeVisualEffectsSetup
  {
    public EnemyTypeId EnemyId;
    public EnemyVisualEffectsSetupId VisualEffectsSetupId; 
    public EnemyMeshModel EnemyMeshModelPrefab;
  }
}