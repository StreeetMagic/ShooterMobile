namespace Gameplay.Characters.Enemies
{
  public class EnemyWeaponReloader
  {
    private readonly EnemyConfig _config;

    private int _bulletsInMagazine;

    private EnemyWeaponReloader(EnemyConfig config)
    {
      _config = config;
      _bulletsInMagazine = _config.MagazineCapacity;
    }

    public bool IsEmpty => _bulletsInMagazine == 0;

    public void Reload()
    {
      _bulletsInMagazine = _config.MagazineCapacity;
    }

    public void SpendBullet()
    {
      _bulletsInMagazine--;
    }
  }
}