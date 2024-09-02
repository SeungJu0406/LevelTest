using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test04
{
    public class FireBullet : MonoBehaviour
    {
        [SerializeField] Transform muzzlePoint;

        [SerializeField] Bullet bullet;

        [SerializeField] float rate;

        Coroutine fireRoutine;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (fireRoutine == null)
                {
                    fireRoutine = StartCoroutine(FIreRoutine());
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                if (fireRoutine != null)
                {
                    StopCoroutine(fireRoutine);
                    fireRoutine = null;
                }
            }
        }
        IEnumerator FIreRoutine()
        {
            WaitForSeconds delay = new(rate);
            while (true)
            {
                Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
                yield return delay;
            }
        }
    }

}
