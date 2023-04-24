using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace InventoryTest
{
    public class SlotManager : MonoBehaviour, ISlot, IPlaceable
    {
        [SerializeField] private Image _lockImage;
        private InventoryItemController _currentItem = null;
        private SlotUseCase _slotUseCase;
        private void Awake()
        {
            _slotUseCase = new SlotUseCase(this);
        }
        public void PutItem(InventoryItemController item)
        {
            _currentItem = item;
            _currentItem.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
            _currentItem.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }
        public InventoryItemController GetItem()
        {
            return _currentItem;
        }
        public InventoryItemModel GetModel()
        {
            if (_currentItem != null) return _currentItem.ItemData;
            else return null;
        }
        public void DestroySlotItem()
        {
            _currentItem?.DestroyItem();
        }
        public bool IsEmpty()
        {
            return _currentItem == null;
        }
        public void SetLockedView(bool isLocked)
        {
            _lockImage.gameObject.SetActive(isLocked);
        }
        public bool PlaceItem(GameObject objectToPlace)
        {
            if (UseCase.IsFreeAndReady() && objectToPlace.GetComponent<InventoryItemController>()!=null)
            {
                PutItem(objectToPlace.GetComponent<InventoryItemController>());
                return true;
            }
            return false;
        }
        public void DetachSlotItem()
        {
            _currentItem = null;
        }
        public SlotUseCase UseCase => _slotUseCase;
    }
}
