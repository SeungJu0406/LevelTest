using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test06
{
    public class MonsterPool : MonoBehaviour
    {
        [SerializeField] Monster monster;

        [SerializeField] Queue<Monster> monsters;

        [SerializeField][Range(0, 3)] float spawnPosRange;

        [SerializeField] float respawnTime;

        [SerializeField] int size;

        Coroutine respawnRoutine;
        private void Awake()
        {
            monsters = new Queue<Monster>(size);
            for (int i = 0; i < size; i++)
            {
                Monster instance = Instantiate(monster);
                instance.gameObject.SetActive(false);
                instance.transform.parent = transform;
                instance.monsterPool = this;
                monsters.Enqueue(instance);
            }
        }
        private void Start()
        {
            for (int i = 0; i < size; i++)
            {
                GetPool();
            }
        }
        public Monster GetPool()
        {
            if (monsters.Count > 0)
            {
                Monster instance = monsters.Dequeue();
                Vector3 spawnPos = new(
                    Random.Range(transform.position.x - spawnPosRange, transform.position.x + spawnPosRange),
                    transform.position.y,
                    Random.Range(transform.position.z - spawnPosRange, transform.position.z + spawnPosRange));
                instance.transform.position = spawnPos;
                instance.transform.rotation = transform.rotation;
                instance.transform.parent = null;
                instance.gameObject.SetActive(true);
                return instance;
            }
            return null;
        }

        public void ReturnPool(Monster instance)
        {
            instance.transform.parent = transform;
            instance.gameObject.SetActive(false);
            monsters.Enqueue(instance);
            respawnRoutine = StartCoroutine(RespawnRoutine());
        }

        IEnumerator RespawnRoutine()
        {
            WaitForSeconds delay = new(respawnTime);
            yield return delay;
            GetPool();
        }
    }
}

