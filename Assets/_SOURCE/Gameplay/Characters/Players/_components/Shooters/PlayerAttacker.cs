using CurrencyRepositories.BackpackStorages;
using Gameplay.Characters.Players.TargetHolders;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerAttacker : MonoBehaviour
  {
    [Inject] private PlayerProvider _playerProvider;
    [Inject] private BackpackStorage _backpackStorage;
    [Inject] private PlayerWeaponRaiser _playerWeaponRaiser;
    [Inject] private WeaponAttacker _weaponAttacker;

    private PlayerTargetHolder PlayerTargetHolder => _playerProvider.PlayerTargetHolder;

    private void Update()
    {
      if (_backpackStorage.IsFull)
        return;

      if (_playerProvider.Player == null)
        return;

      if (_playerWeaponRaiser.IsRaised == false)
        return;

      if (PlayerTargetHolder.HasTarget)
        _weaponAttacker.Attack();
      else 
        _weaponAttacker.ResetCooldown();
    }
  }
}