using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class AmmoItemController : InventoryItemController, IAmmo
    {
        private AmmoUseCase _ammoUseCase;
        private void Awake()
        {
            _ammoUseCase = new AmmoUseCase(this);
        }
        public AmmoModel GetAmmoData()
        {
            return (AmmoModel)ItemData;
        }

        public override bool IsSameItemClass(InventoryItemController item)
        {
            return ((item is AmmoItemController) && (((AmmoModel) item.ItemData).WeaponAmmo == GetAmmoData().WeaponAmmo));
        }

        /*public override bool IsSameItemClass(InventoryItemModel model)
        {
            return (model is AmmoModel);
        }*/

        public AmmoUseCase UseCase => _ammoUseCase;
    }
}
