using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameLoopGameBootstrapper : MonoBehaviour
{
  private PlayerFactory _playerFactory;

  [Inject]
  public void Construct(PlayerFactory playerFactory)
  {
    _playerFactory = playerFactory;
  }

  void Start()
  {
    _playerFactory.Create(transform);
  }
}