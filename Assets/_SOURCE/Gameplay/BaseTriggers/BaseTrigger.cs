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
  }
}