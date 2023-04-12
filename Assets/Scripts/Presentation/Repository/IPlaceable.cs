using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventoryTest
{
    public interface IPlaceable
    {
        public bool PlaceItem(GameObject objectToPlace);
    }
}
