using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Test06
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] Text scoreUI;
        private void Update()
        {
            scoreUI.text = $"Best: {Manager.Score.bestScore}\nScore: {Manager.Score.curScore}";
        }
    }

}
