using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
  private PlayerInputHandler _inputHandler;

  public Player(IInstantiator instantiator)
  {
    _inputHandler = instantiator.Instantiate<PlayerInputHandler>();
    _inputHandler.Init(GetComponent<PlayerMover>());
  }
}