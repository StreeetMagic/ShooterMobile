namespace Infrastructure.VisualEffects
{
  public enum VisualEffectId
  {
    Unknown = 0,

    PlayerBulletImpact = 1, //надо удалить
    PlayerMuzzleFlash = 2, //надо удалить

    // AssaultRifleBulletImpact = 100,
    // PistolBulletImpact = 101,
    // SniperBulletImpact = 102,
    
    HenExplosion = 3, 
    EnemyBulletImpact = 4, //надо удалить
    EnemyMuzzleFlash = 5, //надо удалить
    
    //Партиклы грейдов персонажа
    PlayerSmallGradeReward = 10,
    PlayerBigGradeReward = 11,
    
    //Партикл взрыва гранат
    GrenadeExplosion = 100,
    
    //Партиклы пистолетной стрельбы
    PistolMuzzleFlash = 101,
    PistolBullet = 102,
    PistolImpactExplosion = 103,
    
    //Партиклы винтовочной стрельбы
    RiffleMuzzleFlash = 104,
    RiffleBullet = 105,
    RiffleImpactExplosion = 106,
    
    //Партиклы дробовикочной стрельбы
    ShotgunMuzzleFlash = 107,
    ShotgunBullet = 108,
    ShotgunImpactExplosion = 109,
    
    //Партиклы снайперской стрельбы
    SniperMuzzleFlash = 110,
    SniperBullet = 111,
    SniperImpactExplosion = 112,
  }
}