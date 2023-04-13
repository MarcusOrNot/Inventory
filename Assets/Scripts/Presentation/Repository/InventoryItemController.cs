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
        //private InventoryItemModel _itemData;
        private ISlot _currentParent = null;

        /*public void SetData(InventoryItemModel itemData)
        {
            _itemData = itemData;
            RefreshView();
        }*/

        public abstract void SetData<T>(T itemData) where T : InventoryItemModel;
        protected abstract InventoryItemModel GetData();

        public void RefreshView()
        {
            _icon.sprite = ItemData.Icon;
            _countText.text = ItemData.Count.ToString();
            _countText.gameObject.SetActive(ItemData.Count > 1);
        }
        //public InventoryItemModel ItemData => _itemData;

        public InventoryItemModel ItemData { 
            get => GetData(); 
            /*set
            {
                _itemData = value;
                //RefreshData();
            } */
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
            //WeaponItemController item = GetComponent<WeaponItemController>();
            //if (item != null)
              //  Debug.Log(item.GetWeaponData().Weapon.ToString());

            //Debug.Log(objectToPlace.name);
            //InventoryItemController item = objectToPlace.GetComponent<InventoryItemController>();
            if (IsSameItemClass(objectToPlace) && objectToPlace.GetComponent<IItem>()!=null)
            {
                IItem itemElem = objectToPlace.GetComponent<IItem>();
                //if (item is WeaponItemController)
                //  Debug.Log(((WeaponItemController) item).ItemData.Item.ToString());
                ItemData.Count += itemElem.ItemData.Count;
                RefreshView();
                objectToPlace.GetComponent<IItem>().DestroyItem();
                return true;
                //return false;
            }
            //Debug.Log("In process!");
            return false;
        }
    }
}
