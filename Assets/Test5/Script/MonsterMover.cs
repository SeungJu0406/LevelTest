using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Test05
{
    public class MonsterMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed;

        [SerializeField] float detectDistance;

        [HideInInspector] Transform target;

        [SerializeField] Transform rayPoint;

        bool isDetect;

        Coroutine detectRoutine;

        private void Awake()
        {
            isDetect = false;
        }
        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            detectRoutine = StartCoroutine(DetectRoutine());
        }
        private void Update()
        {
            Move();      
        }

        void Move()
        {
            if (isDetect) 
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
                transform.LookAt(target.position);
            }
        }
        IEnumerator DetectRoutine()
        {
            WaitForSeconds delay = new(0.02f);          
            while (true)
            {
                Vector3 targetDir = target.position - transform.position;

                if (Physics.Raycast(rayPoint.position, targetDir, out RaycastHit hit, detectDistance))
                {
                    if (hit.transform.tag == "Player")
                    {
                        isDetect = true;
                    }
                    else
                    {
                        isDetect = false;
                    }
                }
                else
                {
                    isDetect = false;
                }
                yield return delay;
            }
        }
    }
}

