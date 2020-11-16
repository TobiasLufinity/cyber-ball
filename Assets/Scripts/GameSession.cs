using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // configuration
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] TMP_Text scoreText;

    // state variables
    [SerializeField] private int currentScore;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject secondScoreText = GameObject.Find("Score");
        if (secondScoreText)
        {
            secondScoreText.GetComponent<TMP_Text>().text = currentScore.ToString();
        }
        scoreText.text = currentScore.ToString();
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int points)
    {
        currentScore += points;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
