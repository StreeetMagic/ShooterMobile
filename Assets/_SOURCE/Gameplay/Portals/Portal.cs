using System;
using Gameplay.Characters.Players;
using Gameplay.Portals;
using Projects;
using SceneLoaders;
using Scenes;
using UnityEngine;
using Zenject;

public class Portal : MonoBehaviour
{
  public PortalTypeId TypeId;
  public SceneId ToScene;

  [Inject] private SceneLoader _sceneLoader;
  [Inject] private ProjectData _projectData;

  private bool _playerInTrigger;

  private void Awake()
  {
    Validate();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (_playerInTrigger)
      return;

    if (other.TryGetComponent(out PlayerTargetTrigger _))
    {
      _playerInTrigger = true;

      LoadScene();
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (!_playerInTrigger)
      return;

    if (other.TryGetComponent(out PlayerTargetTrigger _))
    {
      Debug.Log("Игрок вышел");
    }
  }

  private void LoadScene()
  {
    switch (TypeId)
    {
      case PortalTypeId.Unknown:
        throw new ArgumentOutOfRangeException();

      case PortalTypeId.CoreToArena:
        _sceneLoader.Load(ToScene);
        break;

      case PortalTypeId.ArenaToCore:
        switch (_projectData.GameMode)
        {
          case GameMode.Unknown:
            throw new ArgumentOutOfRangeException();

          case GameMode.Default:
            _sceneLoader.Load(ToScene);
            break;

          case GameMode.VladTest:
            _sceneLoader.Load(SceneId.VladTestScene);
            break;

          case GameMode.SimeonTest:
            _sceneLoader.Load(SceneId.SimeonTestScene);
            break;

          case GameMode.ValeraTest:
            _sceneLoader.Load(SceneId.ValeraTestScene);
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        break;

      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  private void Validate()
  {
    if (TypeId == PortalTypeId.Unknown || ToScene == SceneId.Unknown)
      throw new Exception("PortalTypeId or ToScene is unknown");
    
    
  }
}