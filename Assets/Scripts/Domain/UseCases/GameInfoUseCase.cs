using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class GameInfoUseCase
    {
        int currentMoney = 0;
        [Inject]
        public GameInfoUseCase(SavedDataUseCase _savedData)
        {
            currentMoney = _savedData.GetMoney();
        }
        public void AddMoney(int profit)
        {
            currentMoney += profit;
        }
        public bool TrySpendMoney(int expenses)
        {
            if (expenses <= currentMoney)
            {
                currentMoney -= Mathf.Min(currentMoney, expenses);
                return true;
            }
            else return false;
        }
        public int Balance => currentMoney;
    }
}
