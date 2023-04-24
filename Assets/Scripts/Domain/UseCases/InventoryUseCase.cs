using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class InventoryUseCase
    {
        private IContainerInventory _containerRepo;
        public InventoryUseCase(IContainerInventory repo)
        {
            _containerRepo = repo;
        }
    }
}
