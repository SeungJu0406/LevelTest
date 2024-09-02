using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test03
{
    public class Monster : MonoBehaviour, IHit
    {
        [SerializeField] int hp;

        public void Hit(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Die();
            }
        }
        void Die()
        {
            Destroy(gameObject);
        }
    }

}
