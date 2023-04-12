using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Items", menuName = "Items Info")]
    public class ItemsInfo : ScriptableObject
    {
        [SerializeField] private List<WeaponData> _weaponsList;
        [SerializeField] private List<AmmoData> _ammoList;
        [SerializeField] private List<HeadData> _headList;
        [SerializeField] private List<TorsoData> _torsoList;

        public List<WeaponData> WeaponsList => _weaponsList;
        public List<AmmoData> AmmoList => _ammoList;
        public List<HeadData> HeadList => _headList;
        public List<TorsoData> TorsoList => _torsoList;
    }
}
