using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class HeadItemController : InventoryItemController, IHead
    {
        public HeadModel GetHeadData()
        {
            return (HeadModel)ItemData;
        }

        public override bool IsSameItemClass(InventoryItemController item)
        {
            return (item is HeadItemController && ((HeadModel) item.ItemData).Head == GetHeadData().Head);
        }

        /*public override bool IsSameItemClass(InventoryItemModel model)
        {
            return (model is HeadModel);
        }*/
    }
}
