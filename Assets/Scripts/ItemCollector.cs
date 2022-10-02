using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace Assets.Scripts
{
    public class ItemCollector : NetworkBehaviour
    {
        [SerializeField]
        private int Level = 1;
        [SerializeField]
        private int Xp = 0;
        [SerializeField] 
        private int XpNeeded = 100;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "ItemDrop")
            {
                var value = collision.gameObject.GetComponent<ItemDrop>().Pickup();
                Xp += value;
            }
        }
    }
}
