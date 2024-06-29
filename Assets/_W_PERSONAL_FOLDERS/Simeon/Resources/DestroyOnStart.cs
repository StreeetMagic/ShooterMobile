using UnityEngine;

namespace Simeon.Resources
{
    public class DestroyOnStart : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject);
        }
    }
}