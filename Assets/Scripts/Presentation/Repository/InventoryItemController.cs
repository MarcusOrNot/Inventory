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
        private InventoryItemModel _itemData;
        private ISlot _currentParent = null;

        public void SetData(InventoryItemModel itemData)
        {
            _itemData = itemData;
            RefreshView();
        }
        public void RefreshView()
        {
            _icon.sprite = _itemData.Icon;
            _countText.text = _itemData.Count.ToString();
            _countText.gameObject.SetActive(_itemData.Count > 1);
        }
        //public InventoryItemModel ItemData => _itemData;

        public InventoryItemModel ItemData { 
            get => _itemData; 
            set
            {
                _itemData = value;
                //RefreshData();
            } 
        }

        public abstract bool IsSameItemClass(InventoryItemController item);

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
            //Debug.Log("End drag Item on "+ eventData.pointerEnter.name);
            IPlaceable place = eventData.pointerEnter.GetComponent<IPlaceable>();
            if (place!=null && place.PlaceItem(this.gameObject))
            {
                //_currentParent?.DetachSlotItem();
            }
            else
            {
                _currentParent.PutItem(this);
            }
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public bool PlaceItem(GameObject objectToPlace)
        {
            //Debug.Log(objectToPlace.name);
            /*InventoryItemController item = objectToPlace.GetComponent<InventoryItemController>();
            if (item != null && IsSameItemClass(item))
            {
                item.DestroyItem();
                return true;
            }*/
            Debug.Log("In process!");
            return false;
        }
    }
}
