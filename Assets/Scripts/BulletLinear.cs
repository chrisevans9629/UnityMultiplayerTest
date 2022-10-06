using Unity.Netcode;
using UnityEngine;

namespace Assets
{

    public class BulletLinear : NetworkBehaviour
    {

        private Bullet bullet;
        void Start()
        {
            bullet = GetComponent<Bullet>();
        }

        private void Update()
        {
            if (!IsServer)
                return;
            transform.position += bullet.Direction.normalized * bullet.Speed * Time.deltaTime;
        }
    }
}
