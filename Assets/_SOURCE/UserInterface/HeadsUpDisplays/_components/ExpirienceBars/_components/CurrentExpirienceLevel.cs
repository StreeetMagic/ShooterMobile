using Infrastructure.DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

public class CurrentExpirienceLevel : MonoBehaviour
{
  public TextMeshProUGUI Text;

  private ExpierienceStorage _expierienceStorage;

  [Inject]
  public void Construct(ExpierienceStorage expierienceStorage)
  {
    _expierienceStorage = expierienceStorage;
  }

  private void OnEnable()
  {
    SetText(_expierienceStorage.CurrentLevel);
    _expierienceStorage.AllPoints.ValueChanged += SetText;
  }

  private void OnDisable()
  {
    _expierienceStorage.AllPoints.ValueChanged -= SetText;
  }

  private void SetText(int value)
  {
    Text.text = _expierienceStorage.CurrentLevel.ToString();
  }
}