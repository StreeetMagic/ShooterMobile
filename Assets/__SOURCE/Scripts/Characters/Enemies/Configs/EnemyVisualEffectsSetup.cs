using System;
using Infrastructure.VisualEffects;

namespace Gameplay.Characters.Enemies.Configs
{
  [Serializable]
  public class EnemyVisualEffectsSetup
  {
    public EnemyVisualEffectsSetupId SetupId;
        
    public VisualEffectId MuzzleFlashId;
    public VisualEffectId Bullet;
    public VisualEffectId Impact;
    public VisualEffectId Panic;
  }
}