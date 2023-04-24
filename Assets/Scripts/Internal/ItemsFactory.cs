using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class ItemsFactory
    {
        [Inject] private ItemsInfo _itemsInfo;
        [Inject] private WeaponItemController _weaponPrefub;
        [Inject] private AmmoItemController _ammoPrefub;
        [Inject] private HeadItemController _headPrefub;
        [Inject] private TorsoItemController _torsoPrefub;
        private T InstantiateObject<T>(GameObject prefub, SlotManager inSlot) where T: InventoryItemController
        {
            var resObject = GameObject.Instantiate(prefub, inSlot.transform);
            var res = resObject.GetComponent<T>();
            inSlot.PutItem(res);
            return res;
        }
        public void InstantiateItemFromModel(InventoryItemModel modelData, SlotManager inSlot)
        {
            switch (modelData.Item)
            {
                case ItemType.Weapon:
                    WeaponItemController weaponItem = InstantiateObject<WeaponItemController>(_weaponPrefub.gameObject, inSlot);
                    weaponItem.SetData(_itemsInfo.GetDataByType<WeaponModel>(modelData));
                    break;
                case ItemType.Ammo:
                    AmmoItemController ammoItem = InstantiateObject<AmmoItemController>(_ammoPrefub.gameObject, inSlot);
                    ammoItem.SetData(_itemsInfo.GetDataByType<AmmoModel>(modelData));
                    break;
                case ItemType.Head:
                    HeadItemController headItem = InstantiateObject<HeadItemController>(_headPrefub.gameObject, inSlot);
                    headItem.SetData(_itemsInfo.GetDataByType<HeadModel>(modelData));
                    break;
                case ItemType.Torso:
                    TorsoItemController torsoItem = InstantiateObject<TorsoItemController>(_torsoPrefub.gameObject, inSlot);
                    torsoItem.SetData(_itemsInfo.GetDataByType<TorsoModel>(modelData));
                    break;
            }
        }
    }
}
