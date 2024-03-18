using Gameplay.Characters.Enemies.TargetTriggers;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.TargetLocators;
using UnityEngine;
using Zenject;

namespace Gameplay.BaseTriggers
{
  public class BaseTrigger : MonoBehaviour
  {
    [Inject]
    public void Construct()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out TargetTrigger playerTrigger))
      {
        if (playerTrigger.transform.parent.TryGetComponent(out Player player))
        {
          Debug.Log("Зашел игрок");
        }
      }
    }
  }
}