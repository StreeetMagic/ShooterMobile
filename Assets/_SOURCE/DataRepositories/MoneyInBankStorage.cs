using System;
using Infrastructure.PersistentProgresses;
using Infrastructure.SaveLoadServices;
using Infrastructure.Utilities;
using UnityEngine;
using Zenject;

namespace Infrastructure.DataRepositories
{
  public class MoneyInBankStorage : IProgressWriter
  {
    private readonly SaveLoadService _saveLoadService;

    public MoneyInBankStorage(SaveLoadService saveLoadService)
    {
      _saveLoadService = saveLoadService;
      MoneyInBank = new ReactiveProperty<int>();
    }

    public ReactiveProperty<int> MoneyInBank { get; }

    public void ReadProgress(Progress progress) =>
      MoneyInBank.Value = progress.MoneyInBank;

    public void WriteProgress(Progress progress) =>
      progress.MoneyInBank = MoneyInBank.Value;
  }
}