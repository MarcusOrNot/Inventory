using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace InventoryTest
{
    public abstract class InventoryItemController : MonoBehaviour, IItem, IPlaceable, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _countText;
        private ISlot _currentParent = null;
        public abstract void SetData<T>(T itemData) where T : InventoryItemModel;
        protected abstract InventoryItemModel GetData();

        public void RefreshView()
        {
            _icon.sprite = ItemData.Icon;
            _countText.text = ItemData.Count.ToString();
            _countText.gameObject.SetActive(ItemData.Count > 1);
        }
        public InventoryItemModel ItemData { 
            get => GetData(); 
        }
        public abstract bool IsSameItemClass(GameObject item);
        public void DestroyItem()
        {
            Destroy(gameObject);
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _currentParent = this.GetComponentInParent<ISlot>();
            _currentParent.DetachSlotItem();
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            this.gameObject.transform.SetParent(GlobalData.BaseUI);
        }
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 dragPos = Camera.main.ScreenToWorldPoint(eventData.position);
            transform.position = dragPos;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            IPlaceable place = eventData.pointerEnter.GetComponent<IPlaceable>();
            if (place==null || place.PlaceItem(this.gameObject)==false)
                _currentParent.PutItem(this);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        public bool PlaceItem(GameObject objectToPlace)
        {
            if (IsSameItemClass(objectToPlace) && objectToPlace.GetComponent<IItem>()!=null)
            {
                IItem itemElem = objectToPlace.GetComponent<IItem>();
                ItemData.Count += itemElem.ItemData.Count;
                RefreshView();
                objectToPlace.GetComponent<IItem>().DestroyItem();
                return true;
            }
            return false;
        }
    }
}
