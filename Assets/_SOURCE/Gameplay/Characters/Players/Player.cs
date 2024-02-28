using Gameplay.Characters.Players.Movers;
using UnityEngine;

namespace Gameplay.Characters.Players
{
  public class Player : MonoBehaviour
  {
    private PlayerInputHandler _inputHandler;

    public Player(PlayerInputHandler inputHandler)
    {
      _inputHandler = inputHandler;
    }
  }
}