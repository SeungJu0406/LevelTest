using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test06
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] Rigidbody bulletRb;

        [SerializeField] Collider colliderRb;
        [Header(("Gun Status"))]
        [SerializeField] float duration;

        [SerializeField] float speed;

        [SerializeField] int damage;

        Coroutine durationRoutine;
        private void OnEnable()
        {
            bulletRb.velocity = Vector3.zero;
            bulletRb.angularVelocity = Vector3.zero;
            durationRoutine = StartCoroutine(CheckDuration());
        }
        private void Start()
        {
            Collider player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Collider>();
            Physics.IgnoreCollision(player, colliderRb, true);
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

        private void OnCollisionEnter(Collision collision)
        {
            IHit target = collision.transform.GetComponent<IHit>();
            if (target != null)
            {
                target.Hit(damage);            
            }
            Destroy(gameObject);
        }
    }
}


