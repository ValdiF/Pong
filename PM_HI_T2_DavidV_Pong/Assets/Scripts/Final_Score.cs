using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Final_Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.finalScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif

    }
}
