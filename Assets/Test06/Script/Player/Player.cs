using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Test06
{
    public class Player : MonoBehaviour, IHit
    {
        [SerializeField] int hp;

        public event UnityAction OnDie;
        public void Hit(int damage)
        {
            hp -= damage;
            if(hp <= 0)
            {
                Die();
            }
        }
        public void Die() 
        {
            Destroy(gameObject);
            OnDie?.Invoke();
        }
    }
}

