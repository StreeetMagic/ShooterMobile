using Gameplay.CurrencyRepositories.BackpackStorages;
using Gameplay.Weapons;
using Zenject;

namespace Gameplay.Characters.Players.Shooters
{
  public class PlayerAttacker : ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly BackpackStorage _backpackStorage;
    private readonly PlayerWeaponRaiser _playerWeaponRaiser;
    private readonly WeaponAttacker _weaponAttacker;
    private readonly PlayerTargetHolder _playerTargetHolder;

    public PlayerAttacker(PlayerProvider playerProvider, BackpackStorage backpackStorage,
      PlayerWeaponRaiser playerWeaponRaiser, WeaponAttacker weaponAttacker, PlayerTargetHolder playerTargetHolder)
    {
      _playerProvider = playerProvider;
      _backpackStorage = backpackStorage;
      _playerWeaponRaiser = playerWeaponRaiser;
      _weaponAttacker = weaponAttacker;
      _playerTargetHolder = playerTargetHolder;
    }

    public void Tick()
    {
      if (_backpackStorage.IsFull)
        return;

      if (_playerProvider.Instance == null)
        return;

      if (_playerWeaponRaiser.IsRaised == false)
        return;

      if (_playerTargetHolder.HasTarget)
        _weaponAttacker.Attack();
      else
        _weaponAttacker.ResetValues();
    }
  }
}