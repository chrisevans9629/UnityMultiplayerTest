using Unity.Netcode;
using UnityEngine;

namespace Assets
{
    public class BulletSine : NetworkBehaviour
    {

        [SerializeField]
        private float WaveSize = 1;
        [SerializeField]
        private float Frequency = 1;
        private Bullet bullet;
        void Start()
        {
            bullet = GetComponent<Bullet>();
        }

        private void Update()
        {
            if (!IsServer)
                return;
            
            var angle = Mathf.Atan2(bullet.Direction.x, bullet.Direction.y); //* Mathf.Rad2Deg + Mathf.Sin(Time.deltaTime/Frequency) * WaveSize;

            var dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));

            transform.position += dir.normalized * bullet.Speed * Time.deltaTime;
        }
    }
}
