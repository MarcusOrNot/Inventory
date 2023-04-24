using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace InventoryTest
{
    public class InventoryManager : MonoBehaviour, IContainerInventory
    {
        public int SlotsCount = 30;
        public int SlotsInRow = 5;
        [SerializeField] private GridLayoutGroup _itemsPlace;
        [Inject] private SlotManager _slotPrefub;
        [Inject] private SavedDataUseCase _saveGame;
        [Inject] private ItemsFactory _itemsFactory;
        private List<SlotManager> _slots = new List<SlotManager>();
        private InventoryUseCase _inventoryUseCase;

        private void Awake()
        {
            _inventoryUseCase = new InventoryUseCase(this);
        }
        void Start()
        {
            int useSlotWidth = Mathf.FloorToInt(_itemsPlace.GetComponent<RectTransform>().rect.width / 5);
            float spacing = useSlotWidth * 0.1f;
            _itemsPlace.cellSize = new Vector2(useSlotWidth - spacing, useSlotWidth - spacing);
            _itemsPlace.spacing = new Vector2(spacing, spacing);
            int unblockedCount = SlotsCount - _saveGame.GetBlockedSlots();
            for (int i = 0; i < SlotsCount; i++)
            {
                SlotManager slot = Instantiate(_slotPrefub, _itemsPlace.transform);
                slot.UseCase.Locked = (i >= unblockedCount);
                _slots.Add(slot);
            }
            InitStuff(_saveGame.GetItems());
            }

        public void InitStuff(List<InventoryItemModel> items)
        {
            if (items == null) return;
            for (int i = 0; i < _slots.Count; i++)
            {
                if (i < items.Count)
                {
                    if (items[i] != null && items[i].Item != ItemType.None)
                    {
                        _itemsFactory.InstantiateItemFromModel(items[i], _slots[i]);
                    }
                }
            }
        }
        public List<SlotManager> Slots => _slots;
        public void PutItem(InventoryItemController item)
        {
            _slots[0].PutItem(item);
        }
        private int GetSlotPosition(ISlot slot)
        {
            for (int i = 0; i < _slots.Count; i++)
                if (_slots[i].GetComponent<ISlot>()==slot)
                    return i;
            return 0;
        }
        public List<ISlot> GetEmptySlots()
        {
            List<ISlot> res = new List<ISlot>();
            for (int i=0; i<_slots.Count; i++)
            {
                if (_slots[i].GetItem()==null)
                    res.Add(_slots[i]);
            }
            return res;
        }
        public int GetBlockedSlotsCount()
        {
            int resCount = 0;
            for (int i = 0; i < Slots.Count; i++)
                if (Slots[i].UseCase.Locked)
                    resCount++;
            return resCount;
        }
        public void AddItemByModel(InventoryItemModel modelData, ISlot inSlot)
        {
            int pos = GetSlotPosition(inSlot);
            _itemsFactory.InstantiateItemFromModel(modelData, _slots[pos]);
        }
        public List<ISlot> GetSlots()
        {
            var slots = new List<ISlot>();
            for (int i = 0; i < _slots.Count; i++)
                slots.Add(_slots[i]);
            return slots;
        }
        public void UnblockSlot()
        {
            var blockedSlots = GetBlockedSlotsCount();
            if (blockedSlots>0)
            {
                _slots[_slots.Count-blockedSlots].UseCase.Locked = false;
            }
        }
    }
}
