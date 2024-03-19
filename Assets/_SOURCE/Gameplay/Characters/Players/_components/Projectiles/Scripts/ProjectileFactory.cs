using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

public class ProjectileFactory
{
  private readonly IAssetProvider _assetProvider;
  private readonly IZenjectFactory _zenjectFactory;
  private readonly RandomService _randomService;
  private readonly ProjectileStorage _projectileStorage;
  private readonly VisualEffectFactory _visualEffectFactory;

  public ProjectileFactory(IAssetProvider assetProvider, IZenjectFactory zenjectFactory,
    RandomService randomService, ProjectileStorage projectileStorage, VisualEffectFactory visualEffectFactory)
  {
    _assetProvider = assetProvider;
    _zenjectFactory = zenjectFactory;
    _randomService = randomService;
    _projectileStorage = projectileStorage;
    _visualEffectFactory = visualEffectFactory;
  }

  public void Create(Transform parent, Vector3 rotation)
  {
    string guid = _randomService.GetRandomUniqueId();
    Projectile prefab = _assetProvider.Get<Projectile>();
    Projectile projectile = _zenjectFactory.Instantiate(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
    projectile.transform.SetParent(null);
    projectile.Guid = guid;
    _projectileStorage.Add(guid, projectile);

    _visualEffectFactory.Create(VIsualEffectId.MuzzleFlash, parent.position, parent);
  }
}