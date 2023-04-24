using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class SlotUseCase
    {
        private ISlot _slotRepo;
        private SlotModel data;
        public SlotUseCase(ISlot slotRepo)
        {
            data = new SlotModel(false);
            _slotRepo = slotRepo;
        }
        public bool Locked
        {
            get => data.IsLocked;
            set
            {
                data.IsLocked = value;
                _slotRepo.SetLockedView(value);
            }
        }
        public bool IsFreeAndReady()
        {
            return _slotRepo.IsEmpty() && !Locked;
        }
        public SlotModel SlotData => data;
    }
}
