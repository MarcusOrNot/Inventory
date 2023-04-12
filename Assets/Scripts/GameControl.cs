using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class GameControl : MonoBehaviour
    {
        [Inject] private ItemsInfo _itemsInfo;
        [Inject] private InventoryManager _inventory;
        [Inject] private GameInfoUseCase _gameInfo;
        [Inject] private GameInfoPanelManager _gameInfoPanel;
        //[Inject] private InventoryManager _inventory;
        //[Inject] private WeaponItemController _weaponPrefub;

        public void RandomShoot()
        {
            var ammoItems = _inventory.Slots.FindAll(s=>s.GetModel()?.Item == ItemType.Ammo);
            if (ammoItems.Count > 0)
            {
                AmmoItemController randItem = (AmmoItemController)ammoItems[Random.Range(0, ammoItems.Count)].GetItem();
                randItem.UseCase.SpendBullet();
            }
            else
            {
                Debug.Log("Has now ammo for shooting!!!");
            }
            //
            //((AmmoItemController)ammoItems[0]).SpendSome();
        }

        public void AddRandomAmmo()
        {
            var emptySlots = _inventory.Slots.FindAll(s=>s.UseCase.IsFreeAndReady());
            _itemsInfo.AmmoList.ForEach(info=>
            {
                    /*var randSlot = emptySlots[Random.Range(0, emptySlots.Count)];
                    var ammoModel = new AmmoModel(info.WeaponAmmo, info.MaxCount, info.Icon, info.Weight, info.MaxCount);
                    _inventory.AddItemByModel(ammoModel, randSlot);
                    emptySlots.Remove(randSlot); */
                    AddItemInRandomSlot(new AmmoModel(info.WeaponAmmo, info.MaxCount, info.Icon, info.Weight, info.MaxCount), emptySlots);

            });
        }

        public void AddRandomItem()
        {
            var emptySlots = _inventory.Slots.FindAll(s => s.UseCase.IsFreeAndReady());
            var weaponData = _itemsInfo.WeaponsList[Random.Range(0, _itemsInfo.WeaponsList.Count)];
            AddItemInRandomSlot(new WeaponModel(weaponData.Weapon, weaponData.Damage, weaponData.Icon, weaponData.Weight, 1), emptySlots);
            var headData = _itemsInfo.HeadList[Random.Range(0, _itemsInfo.HeadList.Count)];
            AddItemInRandomSlot(new HeadModel(headData.Head, headData.Defence, headData.Icon, headData.Weight, 1), emptySlots);
            var torsoData = _itemsInfo.TorsoList[Random.Range(0, _itemsInfo.TorsoList.Count)];
            AddItemInRandomSlot(new TorsoModel(torsoData.Torso, torsoData.Deffence, torsoData.Icon, torsoData.Weight, 1), emptySlots);
        }

        private void AddItemInRandomSlot(InventoryItemModel itemModel, List<SlotManager> inSlots)
        {
            if (inSlots.Count > 0)
            {
                var randSlot = inSlots[Random.Range(0, inSlots.Count)]; ;
                _inventory.AddItemByModel(itemModel, randSlot);
                inSlots.Remove(randSlot);
            }
            else
            {
                Debug.Log("Has no empty slots!!!");
                return;
            }
        }

        public void DeleteRandomItem()
        {
            var itemSlots = _inventory.Slots.FindAll(s => s.IsEmpty()==false);
            if (itemSlots.Count > 0)
            {
                var randSlot = itemSlots[Random.Range(0, itemSlots.Count)];
                randSlot.DestroySlotItem();
            }
            else
            {
                Debug.Log("All slots are empty");
            }
        }

        public void TryUnblockSlot()
        {
            if (_inventory.Slots.Count>_inventory.Storage.UnblockedSlots && _gameInfo.TrySpendMoney(_inventory.Storage.UnblockPrice))
            {
                _gameInfoPanel.RefreshBalance();
                _inventory.UnblockSlot();
            }
            else
            Debug.Log("Has no enough money!!!");
        }
        public void SaveData()
        {
            _inventory.SaveCurrentData();
        }
    }
}
