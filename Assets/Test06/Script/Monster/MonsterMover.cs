using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

namespace Test06
{
    public class MonsterMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed;

        [SerializeField] float detectDistance;

        [HideInInspector] Transform target;

        [SerializeField] Transform rayPoint;

        bool isDetect;

        bool canMove;

        Coroutine detectRoutine;

        private void Awake()
        {
            isDetect = false;
        }
        private void OnEnable()
        {
            canMove = true; 
            isDetect = false;
        }
        private void Start()
        { 
            Manager.Game.OnReady += SetStop;
            Manager.Game.OnStart += SetStart;
            Manager.Game.OnGameOver += SetStop;
            Manager.Game.OnGameOver += StopRoutine;
            target = GameObject.FindGameObjectWithTag("Player").transform;

        }
        private void Update()
        {
            Move();      
        }
        private void OnDisable()
        {
            StopRoutine();
        }
        public void SetStart()
        {
            canMove = true;
        }
        public void SetStop()
        {
            canMove = false;
        }


        void Move()
        {
            if (!canMove) return;
            if (detectRoutine == null)
            {
                detectRoutine = StartCoroutine(DetectRoutine());
            }
            if (isDetect)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                transform.LookAt(target.position);
            }
            else
            {
                transform.position = transform.position;
            }
        }
        void StopRoutine()
        {
            if (detectRoutine != null)
            {
                StopCoroutine(detectRoutine);
                detectRoutine = null;
            }
        }
        IEnumerator DetectRoutine()
        {
            WaitForSeconds delay = new(0.02f);          
            while (true)
            {
                if (target == null) yield break;

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

