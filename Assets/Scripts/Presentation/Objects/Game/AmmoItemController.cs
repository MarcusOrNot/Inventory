using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class AmmoItemController : InventoryItemController, IAmmo
    {
        private AmmoModel _ammoData;
        private AmmoUseCase _ammoUseCase;
        private void Awake()
        {
            _ammoUseCase = new AmmoUseCase(this);
        }
        public AmmoModel GetAmmoData()
        {
            return _ammoData;
        }
        public override void SetData<T>(T itemData)
        {
            _ammoData = itemData as AmmoModel;
            RefreshView();
        }
        protected override InventoryItemModel GetData()
        {
            return _ammoData;
        }
        public override bool IsSameItemClass(GameObject item)
        {
            IAmmo current = item.GetComponent<IAmmo>();
            if (current != null && current.GetAmmoData().AmmoType == _ammoData.AmmoType) return true;
            return false;
        }
        public AmmoUseCase UseCase => _ammoUseCase;
    }
}
