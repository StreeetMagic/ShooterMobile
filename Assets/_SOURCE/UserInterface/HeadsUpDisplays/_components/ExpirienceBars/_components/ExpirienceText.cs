using Infrastructure.DataRepositories;
using TMPro;
using UnityEngine;
using Zenject;

public class ExpirienceText : MonoBehaviour
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
        SetText(_expierienceStorage.CurrentExpierience);
        _expierienceStorage.AllPoints.ValueChanged += SetText;
    }   
    
    private void OnDisable()
    {
        _expierienceStorage.AllPoints.ValueChanged -= SetText;
    }

    private void SetText(int value)
    {
        int currentExpierience = _expierienceStorage.CurrentExpierience;
        int expierienceToNextLevel = _expierienceStorage.ExpierienceToNextLevel;
        
        Text.text = $"{currentExpierience}/{expierienceToNextLevel} exp";
    }
}
