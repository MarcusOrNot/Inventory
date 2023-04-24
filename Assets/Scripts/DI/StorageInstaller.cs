using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class StorageInstaller : MonoInstaller
    {
        [SerializeField] private ItemsInfo _itemsInfo;
        [SerializeField] private DefaultGameData _defaultGameData;
        public override void InstallBindings()
        {
            Container.Bind<ItemsInfo>().FromInstance(_itemsInfo).AsSingle().NonLazy();
            Container.Bind<DefaultGameData>().FromInstance(_defaultGameData).AsSingle();
            Container.Bind<IDefaultConfig>().To<DefaultConfigImpl>().FromNew().AsSingle();
            Container.Bind<ISaveGame>().To<SerializedSaveGame>().FromNew().AsSingle();
            Container.Bind<SavedDataUseCase>().FromNew().AsSingle();
            Container.Bind<GameInfoUseCase>().FromNew().AsSingle();
        }
    }
}