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
        private LevelManager LevelManager;

        [SerializeField]
        private NetworkVariable<int> Health = new NetworkVariable<int>(100);

        public override void OnNetworkSpawn()
        {
            LevelManager = GameObject.FindObjectOfType<LevelManager>();
            base.OnNetworkSpawn();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!IsServer)
                return;
            if (collision.transform.tag == "ItemDrop")
            {
                var (type, value) = collision.gameObject.GetComponent<ItemDrop>().Pickup();
                if (type == ItemDropType.Xp)
                    LevelManager.AddXp(value);
                if (type == ItemDropType.Health)
                    Health.Value += value;
            }
        }
    }
}
