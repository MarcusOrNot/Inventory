using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class SavedDataUseCase
    {
        [Inject] private IDefaultConfig _defaultConfig;
        [Inject] private ISaveGame _saveGame;
        public int GetMoney()
        {
            return _saveGame.GetSavedData() == null? _defaultConfig.GetDefaultMoney(): _saveGame.GetSavedData().Money;
        }
        public int GetBlockedSlots()
        {
            return _saveGame.GetSavedData() == null ? _defaultConfig.GetDefaultBlockedSlots() : _saveGame.GetSavedData().UnblockedSlotsCount;
        }
        public List<InventoryItemModel> GetItems()
        {
            return _saveGame.GetSavedData() == null ? new List<InventoryItemModel>() : _saveGame.GetSavedData().Items;
        }
        public void SaveGame(GameDataModel gameData)
        {
            _saveGame.SaveGameData(gameData);
        }
        public void DeleteSaveGame()
        {
            _saveGame.DeleteSaveGame();
        }
    }
}
