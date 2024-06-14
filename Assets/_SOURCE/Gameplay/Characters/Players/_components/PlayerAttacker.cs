using Gameplay.CurrencyRepositories.BackpackStorages;
using Zenject;

namespace Gameplay.Characters.Players
{
  public class PlayerAttacker : ITickable
  {
    private readonly PlayerProvider _playerProvider;
    private readonly BackpackStorage _backpackStorage;
    private readonly PlayerWeaponRaiser _playerWeaponRaiser;
    private readonly PlayerWeaponAttacker _weaponAttacker;
    private readonly PlayerTargetHolder _playerTargetHolder;

    public PlayerAttacker(PlayerProvider playerProvider, BackpackStorage backpackStorage,
      PlayerWeaponRaiser playerWeaponRaiser, PlayerWeaponAttacker weaponAttacker, PlayerTargetHolder playerTargetHolder)
    {
      _playerProvider = playerProvider;
      _backpackStorage = backpackStorage;
      _playerWeaponRaiser = playerWeaponRaiser;
      _weaponAttacker = weaponAttacker;
      _playerTargetHolder = playerTargetHolder;
    }

    public void Tick()
    {
      if (_playerProvider.Instance == null)
        return;

      if (_backpackStorage.IsFull)
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