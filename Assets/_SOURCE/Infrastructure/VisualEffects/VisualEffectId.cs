namespace Infrastructure.VisualEffects
{
  public enum VisualEffectId
  {
    Unknown = 0,

    PlayerBulletImpact = 1, //надо удалить
   // PlayerMuzzleFlash = 2, //надо удалить

    // AssaultRifleBulletImpact = 100,
    // PistolBulletImpact = 101,
    // SniperBulletImpact = 102,
    
    HenExplosion = 3, // Поменять гранута на GrenadeExplosion
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
    
    //Партиклы на враге
    AgroPanicEffect = 200,
    
    //Партиклы пистолетной стрельбы для врагов
    EnemyPistolMuzzleFlash = 201,
    EnemyPistolBullet = 202,
    EnemyPistolImpactExplosion = 203,
    
    //Партиклы винтовочной стрельбы
    EnemyRiffleMuzzleFlash = 204,
    EnemyRiffleBullet = 205,
    EnemyRiffleImpactExplosion = 206,
    
    //Партиклы дробовикочной стрельбы
    EnemyShotgunMuzzleFlash = 207,
    EnemyShotgunBullet = 208,
    EnemyShotgunImpactExplosion = 209,
    
    //Партиклы снайперской стрельбы
    EnemySniperMuzzleFlash = 210,
    EnemySniperBullet = 211,
    EnemySniperImpactExplosion = 212,
    
  }
}