using System;
using UnityEngine;

namespace Gameplay.Rewards
{
  [Serializable]
  public class RewardContentSetup
  {
    public RewardId Id;
    public Sprite Icon;
    public string Name;
    public string Description;
  }
}