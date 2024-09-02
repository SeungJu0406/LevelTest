using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test03
{
    public class FireBullet : MonoBehaviour
    {
        [SerializeField] Transform muzzlePoint;

        [SerializeField] Bullet bullet;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
        void Fire()
        {
            Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
        }
    }

}
