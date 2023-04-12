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
            //Debug.Log("Now init use case");
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
            //Debug.Log("Now spent "+count.ToString());
        }
        public void ReloadAmmo()
        {
            _ammo.ItemData.Count = _ammo.GetAmmoData().MaxCount;
            _ammo.RefreshView();
        }
    }
}
