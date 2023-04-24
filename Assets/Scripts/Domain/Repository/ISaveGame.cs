using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface ISaveGame
    {
        public GameDataModel GetSavedData();
        public void SaveGameData(GameDataModel gameData);
        public void DeleteSaveGame();
    }
}
