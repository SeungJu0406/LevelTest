using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Test06
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instace;

        public int bestScore;

        public int curScore;

        private void Awake()
        {
            if (Instace == null)
            {
                Instace = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            bestScore = 0;
            curScore = 0;
        }

        public void SubsCribe()
        {
            Manager.Game.OnReady += ReadyScore;
            Manager.Game.OnGameOver += GameOverScore;
        }

        void ReadyScore()
        {
            curScore = 0;
        }
        void GameOverScore()
        {
            if (curScore > bestScore)
            {
                bestScore = curScore;
            }
        }
    }
}

