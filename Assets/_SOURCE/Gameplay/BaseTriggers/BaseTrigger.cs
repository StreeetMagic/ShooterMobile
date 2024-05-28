using System.Collections.Generic;
using _Infrastructure.SaveLoadServices;
using _Infrastructure.VisualEffects;
using Cameras;
using CurrencyRepositories;
using CurrencyRepositories.BackpackStorages;
using Gameplay.Characters.Players;
using UnityEngine;
using UserInterface.HeadsUpDisplays;
using Zenject;

namespace Gameplay.BaseTriggers
{
  public class BaseTrigger : MonoBehaviour
  {
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private MoneyInBankStorage _moneyInBankStorage;
    [Inject] private EggsInBankStorage _eggsInBankStorage;
    [Inject] private SaveLoadService _saveLoadService;
    [Inject] private HeadsUpDisplayProvider _headsUpDisplayProvider;
    [Inject] private CameraProvider _cameraProvider;
    [Inject] private ParticleImageFactory _particleImageFactory;

    private void OnTriggerEnter(Collider other)
    {
      if (!other.TryGetComponent(out PlayerTargetTrigger playerTrigger))
        return;

      if (!playerTrigger.transform.parent.TryGetComponent(out Player _))
        return;

      Dictionary<CurrencyId, int> data = _backpackStorage.ReadLoot();

      Transform target = _headsUpDisplayProvider.BaseTriggerTarget.transform;
      Transform parent = _headsUpDisplayProvider.ResourcesSendersContainer.transform;

      foreach (KeyValuePair<CurrencyId, int> loot in data)
      {
        switch (loot.Key)
        {
          case CurrencyId.Money:

            _particleImageFactory.Create(ParticleImageId.MoneySender, _headsUpDisplayProvider.BackpackBarFiller.transform.position, parent, target, loot.Value);
            _moneyInBankStorage.MoneyInBank.Value += loot.Value;
            break;

          case CurrencyId.Eggs:
            _particleImageFactory.Create(ParticleImageId.EggSender, _headsUpDisplayProvider.BackpackBarFiller.transform.position, parent, target, loot.Value);
            _eggsInBankStorage.EggsInBank.Value += loot.Value;
            break;
        }
      }

      _backpackStorage.Clean();
      _saveLoadService.SaveProgress();
    }
  }
}