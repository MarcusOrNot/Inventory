using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class ItemsFactory
    {
        [Inject] private WeaponItemController _weaponPrefub;
        [Inject] private AmmoItemController _ammoPrefub;
        [Inject] private HeadItemController _headPrefub;
        [Inject] private TorsoItemController _torsoPrefub;

        private GameObject InstantiateObject(GameObject prefub, SlotManager inSlot)
        {
            var res = GameObject.Instantiate(prefub, inSlot.transform);
            inSlot.PutItem(res.GetComponent<InventoryItemController>());
            return res;
        }

        public InventoryItemController InstantiateItemFromModel(InventoryItemModel modelData, SlotManager inSlot)
        {
            InventoryItemController item = null;
            switch (modelData.Item)
            {
                case ItemType.Weapon:
                    item = InstantiateObject(_weaponPrefub.gameObject, inSlot).GetComponent<WeaponItemController>();
                    break;
                case ItemType.Ammo:
                    item = InstantiateObject(_ammoPrefub.gameObject, inSlot).GetComponent<AmmoItemController>();
                    break;
                case ItemType.Head:
                    item = InstantiateObject(_headPrefub.gameObject, inSlot).GetComponent<HeadItemController>();
                    break;
                case ItemType.Torso:
                    item = InstantiateObject(_torsoPrefub.gameObject, inSlot).GetComponent<TorsoItemController>();
                    break;
            }
            item.SetData(modelData);
            return item;
        }
    }
}
