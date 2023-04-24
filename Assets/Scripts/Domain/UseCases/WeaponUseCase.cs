using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace InventoryTest
{
    public class WeaponUseCase
    {
        [Inject] private IWeapon _weapon;
    }
}
