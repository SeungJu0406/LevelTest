using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test06
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] GameObject readyUI;
        [SerializeField] GameObject gamaOverUI;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            readyUI.SetActive(false);
            gamaOverUI.SetActive(false);
        }
        private void Start()
        {
            Manager.Game.OnReady += ReadyUI;
            Manager.Game.OnStart += StartUI;
            Manager.Game.OnGameOver += GameOverUI;
        }

        void ReadyUI()
        {
            readyUI.SetActive(true);
            gamaOverUI.SetActive(false);
        }
        void StartUI()
        {
            readyUI.SetActive(false);
            gamaOverUI.SetActive(false);
        }
        void GameOverUI()
        {
            readyUI.SetActive(false);
            gamaOverUI.SetActive(true);
        }
    }

}
