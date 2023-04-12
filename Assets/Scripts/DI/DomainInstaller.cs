using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class DomainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<IItem>().To<InventoryItemController>().FromComponentOnRoot().AsTransient();
            //Container.Bind<ISlot>().To<SlotManager>().AsTransient();
            //Container.Bind<SlotUseCase>().FromInstance(new SlotUseCase()).AsTransient();

            //Container.Bind<IAmmo>().To<AmmoItemController>().AsTransient();
            //Container.Bind<AmmoUseCase>().FromInstance(new AmmoUseCase()).AsTransient().NonLazy();

            //Container.Bind<IWeapon>().To<WeaponItemController>().AsTransient();
            //InventoryManager inventory = 

            //Container.Bind<IContainerInventory>().To((InventoryManager) GameObject.FindObjectsOfType<InventoryManager>()[0]).NonLazy();
            //Container.Bind<InventoryUseCase>().FromNew().AsTransient().NonLazy();

            Container.Bind<IGameInfo>().To<GameInfoImpl>().FromNew().AsSingle();
            Container.Bind<GameInfoUseCase>().FromNew().AsSingle();
        }
    }
}