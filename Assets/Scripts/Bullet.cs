using Unity.Netcode;
using UnityEngine;

namespace Assets
{
    public class Bullet : NetworkBehaviour
    {
        public float Speed = 4;
        public Vector3 Direction;

        public int Health = 1;

        public void Damage(){
            Health--;
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public override void OnNetworkSpawn()
        {
            if (IsServer)
                Destroy(gameObject, 10);
            base.OnNetworkSpawn();
        }

        

    }
}
