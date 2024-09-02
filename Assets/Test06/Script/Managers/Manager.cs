using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test06
{
    public class Manager : MonoBehaviour
    {
        public static GameManager Game { get { return GameManager.Instance; } }

        public static UIManager UI { get { return UIManager.Instance; } }

        public static ScoreManager Score { get { return ScoreManager.Instace; } }
        private void OnEnable()
        {
            GameManager.Create();
        }

        private void Start()
        {
            Score.SubsCribe();
        }

    }

}
