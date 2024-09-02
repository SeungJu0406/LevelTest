using UnityEngine;

namespace Test06
{
    public class Monster : MonoBehaviour, IHit
    {
        [SerializeField] public MonsterPool monsterPool;

        [SerializeField] int hp;

        [SerializeField] int damage;

        bool canHit;
        void Start()
        {
            Manager.Game.OnReady += SetCantHit;
            Manager.Game.OnStart += SetCanHit;

        }

        void SetCanHit()
        {
            canHit = true;
        }
        void SetCantHit()
        {
            canHit = false;
        }

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
            Manager.Score.curScore++;
            monsterPool.ReturnPool(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Player")
            {
                IHit target = collision.transform.GetComponent<IHit>();
                target.Hit(damage);
            }
        }
    }

}
