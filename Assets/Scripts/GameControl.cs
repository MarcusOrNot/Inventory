using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace InventoryTest
{
    public class GameControl : MonoBehaviour
    {
        [Inject] private ItemsInfo _itemsInfo;
        [Inject] private InventoryManager _inventory;
        [Inject] private GameInfoUseCase _gameInfo;
        [Inject] private GameInfoPanelManager _gameInfoPanel;
        [Inject] private SavedDataUseCase _saveGame;
        [Inject] private IDefaultConfig _defaultGameData;
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
        }
        public void AddRandomAmmo()
        {
            var emptySlots = _inventory.Slots.FindAll(s=>s.UseCase.IsFreeAndReady());
            _itemsInfo.AmmoList.ForEach(info=>
            {
                AddItemInRandomSlot(new AmmoModel(info.AmmoType, info.MaxCount, info.Icon, info.Weight, info.MaxCount), emptySlots);
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
            if (_inventory.GetBlockedSlotsCount()>0 && _gameInfo.TrySpendMoney(_defaultGameData.GetUnblockPrice()))
            {
                _gameInfoPanel.RefreshBalance();
                _inventory.UnblockSlot();
            }
            else
            Debug.Log("Has no enough money!!!");
        }
        public void SaveData()
        {
            var items = new List<InventoryItemModel>();
            _inventory.Slots.ForEach((slot) => items.Add(slot.GetModel()));
            _saveGame.SaveGame(new GameDataModel(_gameInfo.Balance, _inventory.GetBlockedSlotsCount(), items));
            Debug.Log("Now data saved!");
        }
        public void RestoreDefaults()
        {
            _saveGame.DeleteSaveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Savedata deleted!");
        }
    }
}
