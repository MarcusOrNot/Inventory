using UnityEngine;
using Zenject;

namespace InventoryTest {
    public class PrefubsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SlotManager>().FromComponentInNewPrefabResource("Prefubs/UI/Slot").AsCached().NonLazy();
            Container.Bind<WeaponItemController>().FromComponentInNewPrefabResource("Prefubs/GameObjects/WeaponPrefub").AsCached().NonLazy();
            Container.Bind<AmmoItemController>().FromComponentInNewPrefabResource("Prefubs/GameObjects/AmmoPrefub").AsCached().NonLazy();
            Container.Bind<HeadItemController>().FromComponentInNewPrefabResource("Prefubs/GameObjects/HeadPrefub").AsCached().NonLazy();
            Container.Bind<TorsoItemController>().FromComponentInNewPrefabResource("Prefubs/GameObjects/TorsoPrefub").AsCached().NonLazy();
        }
    }
}