using Cinemachine;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;

namespace _SOURCE.Cameras
{
  public class CameraFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _factory;
    private readonly PlayerFactory _playerFactory;

    public CameraFactory(IZenjectFactory factory, IAssetProvider assetProvider, PlayerFactory playerFactory)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _playerFactory = playerFactory;
    }

    public void Create(Transform parent)
    {
      var prefab = _assetProvider.Get<TopDownCamera>();
      TopDownCamera camera = _factory.Instantiate(prefab, parent);
      camera.transform.SetParent(null);

      Player player = _playerFactory.Player;

      var cmCam = camera.GetComponent<CinemachineVirtualCamera>();

      if (cmCam == null)
      {
        Debug.Log("Camera not found");
      }

      cmCam.Follow = player.transform;
      cmCam.LookAt = player.transform;
    }
  }
}