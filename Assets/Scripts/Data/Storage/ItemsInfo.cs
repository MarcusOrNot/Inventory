using System;
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

        public T GetDataByType<T>(InventoryItemModel itemBase) where T: InventoryItemModel
        {
            switch (itemBase.Item)
            {
                case ItemType.None: return null;
                case ItemType.Weapon:
                    WeaponData weapon = _weaponsList.Find(w => (int)w.Weapon == itemBase.ItemVersion);
                    return (T)Convert.ChangeType(new WeaponModel(weapon.Weapon, weapon.Damage, weapon.Icon, weapon.Weight, itemBase.Count), typeof(T));
                case ItemType.Ammo:
                    AmmoData ammo = _ammoList.Find(a => (int)a.AmmoType == itemBase.ItemVersion);
                    return (T)Convert.ChangeType(new AmmoModel(ammo.AmmoType, ammo.MaxCount, ammo.Icon, ammo.Weight, itemBase.Count), typeof(T));
                case ItemType.Head:
                    HeadData head = _headList.Find(h => (int)h.Head == itemBase.ItemVersion);
                    return (T)Convert.ChangeType(new HeadModel(head.Head, head.Defence, head.Icon, head.Weight, itemBase.Count), typeof(T));
                case ItemType.Torso:
                    TorsoData torso = _torsoList.Find(t => (int)t.Torso == itemBase.ItemVersion);
                    return (T)Convert.ChangeType(new TorsoModel(torso.Torso, torso.Deffence, torso.Icon, torso.Weight, itemBase.Count), typeof(T));
            }

            return null; //(T)Convert.ChangeType(_weaponsList[0], typeof(T));
        }
    }
}
