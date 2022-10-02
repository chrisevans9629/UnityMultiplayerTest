using Unity.Netcode;
using UnityEngine;

namespace Assets
{
    public class Bullet : NetworkBehaviour
    {
        public float Speed = 4;
        public Vector3 Direction;

        private void Update()
        {
            if (!IsServer)
                return;
            transform.position += Direction.normalized * Speed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!IsServer)
                return;
            if (collision.transform.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }


    }
}
