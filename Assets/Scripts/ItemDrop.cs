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

        public int Pickup()
        {
            Destroy(gameObject);
            return Value;
        }
    }
}
