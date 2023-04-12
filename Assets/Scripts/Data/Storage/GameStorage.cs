using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryTest
{
    [CreateAssetMenu(fileName = "Game Storage Data", menuName = "Game Storage")]
    public class GameStorage : ScriptableObject
    {
        public float Money;
    }
}
