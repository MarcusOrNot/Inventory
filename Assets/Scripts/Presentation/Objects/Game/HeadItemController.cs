using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class HeadItemController : InventoryItemController, IHead
    {
        private HeadModel _headData;
        public HeadModel GetHeadData()
        {
            return _headData;
        }

        public override bool IsSameItemClass(GameObject item)
        {
            IHead current = item.GetComponent<IHead>();
            if (current != null && current.GetHeadData().Head == _headData.Head) return true;
            return false;
        }

        public override void SetData<T>(T itemData)
        {
            _headData = itemData as HeadModel;
            RefreshView();
        }

        protected override InventoryItemModel GetData()
        {
            return _headData;
        }

        /*public override bool IsSameItemClass(InventoryItemModel model)
        {
            return (model is HeadModel);
        }*/
    }
}
