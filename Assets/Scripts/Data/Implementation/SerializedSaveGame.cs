using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class SerializedSaveGame : ISaveGame
    {
        private const string SAVEGAME_NAME = "inventory.save";

        public void DeleteSaveGame()
        {
            Utils.DeleteDataFile(SAVEGAME_NAME);
        }

        public GameDataModel GetSavedData()
        {
            var dataString = Utils.RetrieveFromDataPath<string>(SAVEGAME_NAME);
            if (dataString != null)
            {
                return JsonUtility.FromJson<GameDataModel>(dataString);
            }
            return null;
        }

        public void SaveGameData(GameDataModel gameData)
        {
            Utils.SaveFileInDataPath<string>(JsonUtility.ToJson(gameData), SAVEGAME_NAME);
        }
    }
}
