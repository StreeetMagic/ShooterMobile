using System;
using Infrastructure.DataRepositories;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ExpirienceBar : MonoBehaviour
{
  public Image Image;

  private ExpierienceStorage _expierienceStorage;

  [Inject]
  public void Construct(ExpierienceStorage expierienceStorage)
  {
    _expierienceStorage = expierienceStorage;
  }

  private void Update()
  {
    float expierienceStorageExpierienceToNextLevel = (float)_expierienceStorage.CurrentExpierience / _expierienceStorage.ExpierienceToNextLevel;

    Image.fillAmount = 
      Image.fillAmount > expierienceStorageExpierienceToNextLevel 
        ? expierienceStorageExpierienceToNextLevel 
        : Mathf.MoveTowards(Image.fillAmount, expierienceStorageExpierienceToNextLevel, Time.deltaTime);
  }
}