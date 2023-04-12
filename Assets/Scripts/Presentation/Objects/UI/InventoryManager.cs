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
        //[SerializeField] private SlotManager _slotPrefub;
        [Inject] private SlotManager _slotPrefub;
        private List<SlotManager> _slots = new List<SlotManager>();
        //[Inject] private WeaponController _weaponPrefub;
        [Inject] private ItemsFactory _itemsFactory;
        [Inject] private InventoryStorage _inventoryStorage;
        [Inject] private DataOperation _dataOper;
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
            for (int i = 0; i < SlotsCount; i++)
            {
                SlotManager slot = Instantiate(_slotPrefub, _itemsPlace.transform);
                slot.UseCase.Locked = (i>=_inventoryStorage.UnblockedSlots);
                _slots.Add(slot);
                if (i < _inventoryStorage.Items.Count)
                {
                    //LoadItem(_inventoryStorage.Items[i], slot);
                    if (_inventoryStorage.Items[i] != null && _inventoryStorage.Items[i].Item != ItemType.None)
                    {
                        _itemsFactory.InstantiateItemFromModel(_inventoryStorage.Items[i], slot);
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

        public void SaveCurrentData()
        {
            _dataOper.SaveInventoryData(_slots);
        }

        public InventoryStorage Storage => _inventoryStorage;
        public void UnblockSlot()
        {
            if (_inventoryStorage.UnblockedSlots<_slots.Count)
            {
                _slots[_inventoryStorage.UnblockedSlots].UseCase.Locked = false;
                _inventoryStorage.UnblockedSlots++;
            }
        }
    }
}
