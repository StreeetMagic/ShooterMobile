using UnityEngine;

namespace Gameplay.Characters.Questers
{
  [RequireComponent(typeof(OpenQuestButtonEnabler))]
  public class Quester : MonoBehaviour
  {
    public OpenQuestButtonEnabler OpenQuestButtonEnabler;
  }
}