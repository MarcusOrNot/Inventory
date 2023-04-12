using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class StorageInstaller : MonoInstaller
    {
        [SerializeField] private ItemsInfo _itemsInfo;
        [SerializeField] private InventoryStorage _inventoryStorage;
        [SerializeField] private GameStorage _gameStorage;
        public override void InstallBindings()
        {
            Container.Bind<ItemsInfo>().FromInstance(_itemsInfo).AsSingle().NonLazy();
            Container.Bind<InventoryStorage>().FromInstance(_inventoryStorage).AsSingle().NonLazy();
            Container.Bind<GameStorage>().FromInstance(_gameStorage).AsSingle().NonLazy();
        }
    }
}