namespace Infrastructure.VisualEffects
{
  public enum VisualEffectId
  {
    Unknown = 0,

    // PlayerBulletImpact = 1, //надо удалить
    // PlayerMuzzleFlash = 2, //надо удалить

    // AssaultRifleBulletImpact = 100,
    // PistolBulletImpact = 101,
    // SniperBulletImpact = 102,

    HenExplosion = 3, 
    //EnemyBulletImpact = 4, //надо удалить
   // EnemyMuzzleFlash = 5, //надо удалить

    //Партиклы грейдов персонажа
    SmallYellowGradeReward = 10,
    BigYellowGradeReward = 11,

    //Партикл взрыва гранат
    GrenadeExplosion = 100,
    
    //Bullets 101 - 120
    BulletLongRed = 101,
    BulletLongYellow = 102,
    BulletRed = 103,
    BulletYellow = 104,
    
    //Muzzles 121 - 140
    MuzzleStandardRed = 121,
    MuzzleSmallYellow = 122,
    MuzzleStandardYellow = 123,
    MuzzleShotgunStandardYellow = 124,

    //Explosion 141 - 160
    ExplosionSphereSmallRed = 141,
    ExplosionSphereSmallYellow = 142,
    ExplosionStandardRed = 143,
    ExplosionStandardYellow = 144,
    
    //Партиклы на враге
    PanicEffect = 200,
  }
}