using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;

    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private Transform ballTransform;

    private int player1Score;
    private int player2Score;
    public static string finalScore;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        
    }
    public void Player1Scored()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        if (player1Score >= 7)
        {
            finalScore = "Ha ganado el jugador 1";
            LoadNextScene();
        }
    }

    public void Player2Scored()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        if (player2Score >= 7)
        {
            finalScore = "Ha ganado el jugador 2";
            LoadNextScene();
        }
    }

    public void Restart()
    {
        player1Transform.position = new Vector3(player1Transform.position.x, 0, 0);
        player2Transform.position = new Vector3(player2Transform.position.x, 0, 0);
        ballTransform.position = new Vector3(0, 0, 0);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    
}
