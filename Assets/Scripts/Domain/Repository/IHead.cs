using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public interface IHead : IItem
    {
        public HeadModel GetHeadData();
    }
}
