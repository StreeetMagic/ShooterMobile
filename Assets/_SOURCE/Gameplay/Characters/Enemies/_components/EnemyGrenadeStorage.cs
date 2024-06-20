using Gameplay.Characters.Enemies.Configs;

namespace Gameplay.Characters.Enemies
{
  public class EnemyGrenadeStorage
  {
    private int _grenadesLeft;

    public EnemyGrenadeStorage(EnemyConfig config)
    {
      _grenadesLeft = config.MaxGrenadesCount;
    }

    public bool HasGrenades => _grenadesLeft > 0;

    public void SpendGrenade()
    {
      _grenadesLeft--;
    }
  }
}