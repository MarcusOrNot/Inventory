using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class PresentationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ItemsFactory>().FromNew().AsSingle();
            Container.Bind<DataOperation>().FromNew().AsSingle();
        }
    }
}