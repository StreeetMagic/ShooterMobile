using System;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    public Progress Progress { get; private set; }

    public void LoadProgress(string getString) =>
      Progress =
        JsonUtility
          .FromJson<Progress>(getString);

    public void SetDefault() =>
      Progress = new Progress
      {
        MoneyInBank = 20,
        MoneyInBackpack = 30,

        EggsInBank = 40,
        EggsInBackpack = 50,

        PlayerPosition = Vector3.zero
      };
  }

  [Serializable]
  public class Progress
  {
    public int MoneyInBank;
    public int MoneyInBackpack;

    public int EggsInBank;
    public int EggsInBackpack;

    public Vector3 PlayerPosition;
  }
}