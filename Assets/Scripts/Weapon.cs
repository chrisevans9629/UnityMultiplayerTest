using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

namespace Assets
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Bullet BulletPrefab;

        [SerializeField]
        private float Speed = 1;

        [SerializeField]
        private float BulletSpeed = 4;

        [SerializeField]
        private float Range = 10;

        private void Start()
        {
            if (NetworkManager.Singleton.IsServer)
                StartCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            yield return new WaitForSeconds(Speed);
            var enemy = GameObject.FindGameObjectsWithTag("Enemy")
                .Where(p => Vector3.Distance(p.transform.position, transform.position) <= Range)
                .FirstOrDefault();

            if (enemy != null)
            {
                var item = Instantiate(BulletPrefab);
                item.Direction = enemy.transform.position - transform.position;
                item.Speed = BulletSpeed;
                item.transform.position = transform.position;
                item.GetComponent<NetworkObject>().Spawn(true);
            }

            StartCoroutine(Fire());
        }
    }
}
