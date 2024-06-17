using Gameplay.Characters.Enemies;

namespace Gameplay.Characters
{
  public class HitStatus
  {
    private readonly EnemyReturnToSpawnStatus _enemyReturnToSpawnStatus;

    public HitStatus(EnemyReturnToSpawnStatus enemyReturnToSpawnStatus)
    {
      _enemyReturnToSpawnStatus = enemyReturnToSpawnStatus;
    }

    public bool IsHit { get; private set; }

    public void Enable()
    {
      if (IsHit)
        return;

      IsHit = true;
    }

    public void Disable()
    {
      IsHit = false;
    }
  }
}