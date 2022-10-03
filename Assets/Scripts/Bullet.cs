using Unity.Netcode;
using UnityEngine;

namespace Assets
{
    public class Bullet : NetworkBehaviour
    {
        public float Speed = 4;
        public Vector3 Direction;

        public override void OnNetworkSpawn()
        {
            if (IsServer)
                Destroy(gameObject, 10);
            base.OnNetworkSpawn();
        }

        private void Update()
        {
            if (!IsServer)
                return;
            transform.position += Direction.normalized * Speed * Time.deltaTime;
        }

    }
}
