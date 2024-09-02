using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Test06
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        enum GameStatus { Ready, Start, GameOver }

        GameStatus curStatue;

        public event UnityAction OnReady;
        public event UnityAction OnStart;
        public event UnityAction OnGameOver;

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
        }
        private void Start()
        {

            curStatue = GameStatus.Ready;
        }


        private void Update()
        {
            if (curStatue == GameStatus.Ready && !Input.anyKeyDown)
            {
                GameReady();
            }
            if (curStatue == GameStatus.Ready && Input.anyKeyDown)
            {
                GameStart();
            }
            else if (curStatue == GameStatus.GameOver && Input.GetKeyDown(KeyCode.R))
            {
                curStatue = GameStatus.Ready;
                SceneManager.LoadScene("Test06");
            }
        }

        void GameReady()
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.OnDie += GameOver;

            curStatue = GameStatus.Ready;
            OnReady?.Invoke();
        }
        void GameStart()
        {
            curStatue = GameStatus.Start;
            OnStart?.Invoke();
        }
        void GameOver()
        {
            curStatue = GameStatus.GameOver;
            OnGameOver?.Invoke();
        }
        public static void Create()
        {
            if (Instance == null)
            {
                GameManager gameManagerPrefab = Resources.Load<GameManager>("GameManager");
                Instantiate(gameManagerPrefab.gameObject);
            }
        }
        public static void Release()
        {
            if (Instance == null) return;

            Destroy(Instance.gameObject);
            Instance = null;
        }



    }



}
