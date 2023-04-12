using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<InventoryManager>().FromInstance(_inventory).AsTransient().NonLazy();
            //FindObjectOfType<InventoryManager>().gameObject
            InventoryManager _inv = FindObjectOfType<InventoryManager>();
            Container.Bind<InventoryManager>().FromComponentOn(_inv.gameObject).AsSingle().NonLazy();
            Container.Bind<IContainerInventory>().To<InventoryManager>().FromInstance(_inv).AsTransient();

            GameInfoPanelManager gamePanel = FindObjectOfType<GameInfoPanelManager>();
            Container.Bind<GameInfoPanelManager>().FromComponentOn(gamePanel.gameObject).AsSingle();
        }
    }
}