using Characters.Enemies.Configs;

namespace Characters.Enemies._components
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