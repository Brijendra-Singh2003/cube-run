using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;
    public Text speedText;
    public Text highScoreText;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject TitleScreen;
    public ObstacleSpawner obstacleSpawner;
    public GameObject[] gameControls;
    public PlayerController player;
    private bool isGameOver = true;

    private void Awake()
    {
        player.enabled = false;
        Pause();
        Application.targetFrameRate = 60;
    }

    private void Start() 
    {
        highScoreText.text = "High Score:" + PlayerPrefs.GetInt("highScore", 0);
    }

    public void Pause() 
    {
        TitleScreen.SetActive(true);
        Time.timeScale = 0f;
        obstacleSpawner.enabled = false;

        for(int i = 0; i < gameControls.Length; i++) {
            gameControls[i].SetActive(false);
        }
    }

    public void Play() {
        if(isGameOver) {
            score = 0;
            player.transform.position = Vector2.zero;
            scoreText.text = "Score:0";
            TitleScreen.GetComponentInChildren<Text>().text = "Resume";
            player.enabled = true;

            Obsticle[] obsticles = FindObjectsOfType<Obsticle>();
            for (int i = 0; i <  obsticles.Length; i++) {
                Destroy(obsticles[i].gameObject);
            }

            isGameOver = false;
        }

        obstacleSpawner.enabled = true;
        Time.timeScale = 1f;

        TitleScreen.SetActive(false);

        for(int i = 0; i < gameControls.Length; i++) {
            gameControls[i].SetActive(true);
        }
    }

    public void GameOver() 
    {
        isGameOver = true;
        TitleScreen.GetComponentInChildren<Text>().text = "Retry";
        player.enabled = false;
        Pause();

        int highScore = PlayerPrefs.GetInt("highScore", 0);
    
        if (score > highScore)  {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "High Score:" + score;
        }
    }

    public void PlayerScores(int score) 
    {
        this.score = score;
        scoreText.text = "Score:" + score;
    }
    public void SetSpeedText(int speed) 
    {
        speedText.text = "Speed:" + speed + "km/h";
    }
}
