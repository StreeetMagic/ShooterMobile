using System.Collections;
using System.Collections.Generic;
using _SOURCE.Cameras;
using _SOURCE.Maps;
using UnityEngine;
using Zenject;

public class GameLoopGameBootstrapper : MonoBehaviour
{
  private PlayerFactory _playerFactory;
  private MapFactory _mapFactory;
  private CameraFactory _cameraFactory;

  [Inject]
  public void Construct(PlayerFactory playerFactory, MapFactory mapFactory, CameraFactory cameraFactory)
  {
    _playerFactory = playerFactory;
    _mapFactory = mapFactory;
    _cameraFactory = cameraFactory;
  }

  void Start()
  {
    _mapFactory.Create(transform);
    _playerFactory.Create(transform);
    _cameraFactory.Create(transform);
  }
}