using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test05 
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed;

        [SerializeField] float rotateSpeed;

        private void Update()
        {
            Move();
        }
        void Move()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = new(x, 0, z);
            moveDir.Normalize();

            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
            if (x != 0 || z != 0)
            {
                Quaternion rotationDir = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotationDir, rotateSpeed * Time.deltaTime);
            }

        }
    }
}
