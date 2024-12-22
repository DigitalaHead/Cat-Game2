using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject GameOverPanel;
    public GameObject GameOverHiPanel;
    public GameObject PausePanel;
    public GameObject PauseHiPanel;
    private bool isStart;

    public GameObject InvisibleButton;
    public GameObject PauseButton;
    public GameObject Teacher;
    public GameObject NewRecord;

    public float initialGameSpeed = 10f;
    public float gameSpeedIncrease = 5f;
    public float gameSpeed { get; private set; }

    public GameObject label;
    public GameObject labelHI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI scoreText4;
    public TextMeshProUGUI hiscoreText;
    public TextMeshProUGUI hiscoreText1;
    public TextMeshProUGUI hiscoreText2;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;

    private Player player;
    private Spawner spawner;

    private float score;
    public float Score => score;

    private bool isPaused = false;
    private bool flag = true;

    private float startTime;


    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        isStart = false;
        startTime = Time.time;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
            Destroy(obstacle.gameObject);

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        
        retryButton.gameObject.SetActive(true);

        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            GameOverHiPanel.SetActive(true);
        }
        else
        {
            GameOverPanel.SetActive(true);
        }

        UpdateHiscore();
    }


    public void StartGameButtonClick()
    {
        isStart = !isStart;
        Time.timeScale = isStart ? 1f : 0f;
        InvisibleButton.gameObject.SetActive(false);
        Teacher.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Time.time - startTime > 5.0f) // Проверка, прошли ли первые 5 секунды
        {
            Teacher.gameObject.SetActive(false); ; 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();

        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        if (score > hiscore & hiscore > 0 & score > 27 & flag)
        {
            flag = false;
            NewRecord.gameObject.SetActive(true);
            Invoke("DeactivateNewRecord", 5f); // Запланировать вызов функции DeactivateNewRecord через 5 секунд
        }

        if(hiscore == 0)
        {
           hiscore = score;
            hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
            hiscoreText1.text = Mathf.FloorToInt(hiscore).ToString("D5");
            hiscoreText2.text = Mathf.FloorToInt(hiscore).ToString("D5");
        }
        

        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
        scoreText1.text = Mathf.FloorToInt(score).ToString("D5");
        scoreText2.text = Mathf.FloorToInt(score).ToString("D5");
        scoreText3.text = Mathf.FloorToInt(score).ToString("D5");
        scoreText4.text = Mathf.FloorToInt(score).ToString("D5");

    }

    private void DeactivateNewRecord()
    {
        NewRecord.gameObject.SetActive(false);
    }


    public void TogglePause()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);
        if (score > hiscore)
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
                PauseHiPanel.SetActive(true);
                scoreText.gameObject.SetActive(false);
                hiscoreText.gameObject.SetActive(false);
                label.SetActive(false);
                labelHI.SetActive(false);
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1f;
                PauseHiPanel.SetActive(false);
                scoreText.gameObject.SetActive(true);
                hiscoreText.gameObject.SetActive(true);
                label.SetActive(true);
                labelHI.SetActive(true);
            }
        }

        else 
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
                PausePanel.SetActive(true);
                scoreText.gameObject.SetActive(false);
                hiscoreText.gameObject.SetActive(false);
                label.SetActive(false);
                labelHI.SetActive(false);
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1f;
                PausePanel.SetActive(false);
                scoreText.gameObject.SetActive(true);
                hiscoreText.gameObject.SetActive(true);
                label.SetActive(true);
                labelHI.SetActive(true);
            }
        }
       
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)  
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
        hiscoreText1.text = Mathf.FloorToInt(hiscore).ToString("D5");
        hiscoreText2.text = Mathf.FloorToInt(hiscore).ToString("D5");


    }
}