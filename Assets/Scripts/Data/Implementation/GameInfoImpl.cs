using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class GameInfoImpl : IGameInfo
    {
        [Inject] private GameStorage _gameStorage;
        public float Money {
            get => _gameStorage.Money;
            set => _gameStorage.Money = value;
        }
    }
}
