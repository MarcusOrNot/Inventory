using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    public class TorsoItemController : InventoryItemController, ITorso
    {
        private TorsoModel _torsoModel;
        public TorsoModel GetTorsoModel()
        {
            return (TorsoModel)ItemData;
        }

        public override bool IsSameItemClass(GameObject item)
        {
            ITorso current = item.GetComponent<ITorso>();
            if (current != null && current.GetTorsoModel().Torso == _torsoModel.Torso) return true;
            return false;
        }

        public override void SetData<T>(T itemData)
        {
            _torsoModel = itemData as TorsoModel;
            RefreshView();
        }

        protected override InventoryItemModel GetData()
        {
            return _torsoModel;
        }
    }
}
