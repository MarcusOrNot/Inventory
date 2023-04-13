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
                    //WeaponModel some = (WeaponModel)modelData;
                    //WeaponModel newWeapon = new WeaponModel(WeaponType.AssaultRifle, 10, modelData.Icon, modelData.Weight, modelData.Count);
                    weaponItem.SetData(_itemsInfo.GetDataByType<WeaponModel>(modelData));
                    break;
                case ItemType.Ammo:
                    //item = InstantiateObject<AmmoItemController>(_ammoPrefub.gameObject, inSlot).GetComponent<AmmoItemController>();
                    //item.SetData(modelData);
                    AmmoItemController ammoItem = InstantiateObject<AmmoItemController>(_ammoPrefub.gameObject, inSlot);
                    ammoItem.SetData(_itemsInfo.GetDataByType<AmmoModel>(modelData));
                    break;
                case ItemType.Head:
                    //item = InstantiateObject<HeadItemController>(_headPrefub.gameObject, inSlot).GetComponent<HeadItemController>();
                    //item.SetData(modelData);
                    HeadItemController headItem = InstantiateObject<HeadItemController>(_headPrefub.gameObject, inSlot);
                    headItem.SetData(_itemsInfo.GetDataByType<HeadModel>(modelData));
                    break;
                case ItemType.Torso:
                    //item = InstantiateObject<TorsoItemController>(_torsoPrefub.gameObject, inSlot).GetComponent<TorsoItemController>();
                    //item.SetData(modelData);
                    TorsoItemController torsoItem = InstantiateObject<TorsoItemController>(_torsoPrefub.gameObject, inSlot);
                    torsoItem.SetData(_itemsInfo.GetDataByType<TorsoModel>(modelData));
                    break;
            }
        }
    }
}
