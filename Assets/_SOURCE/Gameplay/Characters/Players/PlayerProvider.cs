﻿using Gameplay.Characters.Players.InputHandlers;
using Gameplay.Characters.Players.Movers;
using Gameplay.Characters.Players.Rotators;
using Gameplay.Characters.Players.TargetHolders;
using Gameplay.Characters.Players.TargetLocators;
using UnityEngine;

namespace Gameplay.Characters.Players.Factories
{
  public class PlayerProvider
  {
    public Player Player { get; set; }

    public PlayerMover PlayerMover { get; set; }
    public PlayerRotator PlayerRotator { get; set; }
    public PlayerTargetLocator PlayerTargetLocator { get; set; }

    public PlayerTargetHolder PlayerTargetHolder { get; set; }
    public PlayerRotatorController PlayerRotatorController { get; set; }
    public PlayerInputHandler PlayerInputHandler { get; set; }
    public Transform ShootingPoint { get; set; }
    public PlayerHealth PlayerHealth { get; set; }
  }
}