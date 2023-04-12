using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventoryTest
{
    public class GameInfoPanelManager : MonoBehaviour
    {
        [SerializeField] private Text _balanceText;
        [Inject] private GameInfoUseCase _gameInfo;
        private void Start()
        {
            RefreshBalance();
        }

        public void RefreshBalance()
        {
            _balanceText.text = _gameInfo.Balance.ToString()+"$";
        }
    }
}
