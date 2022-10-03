using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace Assets.Scripts
{
    public class ItemDrop : NetworkBehaviour
    {
        [SerializeField]
        private int Value = 1;

        [SerializeField]
        private ItemDropType Type;
        public (ItemDropType, int) Pickup()
        {
            Destroy(gameObject);
            return (Type, Value);
        }
    }
}
