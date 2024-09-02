using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test02
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] Rigidbody bulletRb;

        [SerializeField] float duration;

        [SerializeField] float speed;

        Coroutine durationRoutine;
        private void OnEnable()
        {
            bulletRb.velocity = Vector3.zero;
            bulletRb.angularVelocity = Vector3.zero;
            durationRoutine = StartCoroutine(CheckDuration());
        }
        private void OnDisable()
        {
            durationRoutine = null;
        }
        private void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            bulletRb.velocity = transform.forward * speed;
        }

        IEnumerator CheckDuration()
        {
            WaitForSeconds delay = new(2f);
            yield return delay;
            Destroy(gameObject);
        }
    }

}

