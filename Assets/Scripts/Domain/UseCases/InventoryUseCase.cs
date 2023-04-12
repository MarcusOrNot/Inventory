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
        
        /*public void AddRandomAmmo()
        {
            var emptySlots = _containerRepo.GetSlots().FindAll(s => s.isEmpty());
            _itemsInfo.AmmoList.ForEach(info =>
            {
                if (emptySlots.Count > 0)
                {
                    var randSlot = emptySlots[Random.Range(0, emptySlots.Count)];
                    var ammoModel = new AmmoModel(info.WeaponAmmo, info.MaxCount, info.Icon, info.Weight, info.MaxCount);
                    _inventory.AddItemByModel(ammoModel, randSlot);
                    emptySlots.Remove(randSlot);
                }
                else
                {
                    Debug.Log("Has no empty slots!!!");
                    return;
                }
            });
        } */
    }
}
