using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class WeaponUseCase
    {
        [Inject] private IWeapon _weapon;
        /*public WeaponUseCase(IWeapon weapon)
        {
            _weapon = weapon;
        } */
        /*public void TryShoot()
        {
            if (_weapon.Ammo > 0) _weapon.Ammo--;
        }*/
    }
}
