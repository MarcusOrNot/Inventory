using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class DataOperation
    {
        [Inject] private InventoryStorage _inventoryStorage;

        public void SaveInventoryData(List<SlotManager> slots)
        {
            Debug.Log("Now must save");
            _inventoryStorage.Items.Clear();
            //_inventoryStorage.Items.Add(slots[0].GetModel());
            //InventoryItemData itemData = null;
            //InventoryStorageElem elem = new InventoryStorageElem();
            //var ammoData = ScriptableObject.CreateInstance<AmmoData>();
            //elem.SetData(ammoData, 1);
            //_inventoryStorage.Items.Add(elem);
            for (int i=0; i<slots.Count; i++)
            {
                var itemData = slots[i].GetModel();
                if (slots[i].IsEmpty() == false)
                {
                    if (itemData.Item == ItemType.Weapon) _inventoryStorage.Items.Add(((WeaponItemController) slots[i].GetItem()).ItemData);
                    else
                    _inventoryStorage.Items.Add(slots[i].GetModel());
                    /*var item = slots[i].GetItem();
                    switch (item.ItemData.Item)
                    {
                        case ItemType.Weapon:
                            WeaponModel someWeapon = (WeaponModel) item.ItemData;
                            var weaponData = new WeaponData();
                            weaponData.SetData(item.ItemData);
                            elem.SetData(weaponData, item.ItemData.Count);
                            break;
                        case ItemType.Ammo:
                            var ammoData = ScriptableObject.CreateInstance<AmmoData>();
                            ammoData.SetData(item.ItemData);
                            elem.SetData(ammoData, item.ItemData.Count);
                            break;
                        case ItemType.Head:
                            var headData = new HeadData();
                            headData.SetData(item.ItemData);
                            elem.SetData(headData, item.ItemData.Count);
                            break;
                        case ItemType.Torso:
                            var torsoData = new TorsoData();
                            torsoData.SetData(item.ItemData);
                            elem.SetData(torsoData, item.ItemData.Count);
                            break; */
                    //
                }
                else _inventoryStorage.Items.Add(null);
            } 
        }
    }
}
