using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class AmmoUseCase
    {
        private IAmmo _ammo;
        public AmmoUseCase(IAmmo ammo)
        {
            _ammo = ammo;
        }
        public void SpendBullet()
        {
            if (_ammo.ItemData.Count > 0)
            {
                _ammo.ItemData.Count--;
                _ammo.RefreshView();
            }
            else _ammo.DestroyItem();
        }
        public void ReloadAmmo()
        {
            _ammo.ItemData.Count = _ammo.GetAmmoData().MaxCount;
            _ammo.RefreshView();
        }
    }
}
