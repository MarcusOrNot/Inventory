using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class GameInfoUseCase
    {
        [Inject] private IGameInfo _gameInfoRepo;
        public void AddMoney(float profit)
        {
            _gameInfoRepo.Money += profit;
        }
        public bool TrySpendMoney(float expenses)
        {
            if (expenses <= _gameInfoRepo.Money)
            {
                _gameInfoRepo.Money -= Mathf.Min(_gameInfoRepo.Money, expenses);
                return true;
            }
            else return false;
        }
        public float Balance => _gameInfoRepo.Money;
    }
}
