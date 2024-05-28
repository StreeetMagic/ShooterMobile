using _Infrastructure.PersistentProgresses;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Infrastructure.UserIntefaces
{
  public abstract class Window : MonoBehaviour
  {
    [SerializeField] private Button CloseButton;

    protected PersistentProgressService ProgressService;

    [Inject]
    public void Construct(PersistentProgressService progressService)
    {
      ProgressService = progressService;
    }

    private void Awake() =>
      OnAwake();

    private void Start()
    {
      Initialize();
      SubscribeUpdates();
    }

    private void OnDestroy() =>
      Cleanup();

    protected virtual void OnAwake() =>
      CloseButton.onClick.AddListener(() => Destroy(gameObject));

    protected virtual void Initialize() { }
    protected virtual void SubscribeUpdates() { }
    protected virtual void Cleanup() { }
  }
}