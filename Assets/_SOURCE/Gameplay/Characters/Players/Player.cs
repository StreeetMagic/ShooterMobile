using System.Collections;
using System.Collections.Generic;
using Players;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
  private PlayerInputHandler _inputHandler;

  public Player(PlayerInputHandler inputHandler)
  {
    _inputHandler = inputHandler;
  }
}