using UnityEngine;
using Zenject;

namespace Vlad.BaseTriggers
{
  public class BaseTrigger : MonoBehaviour
  {
    [Inject]
    public void Construct()
    {
    }
  }
}