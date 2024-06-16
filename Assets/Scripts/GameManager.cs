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
    public playerController player;

    private void Awake()
    {
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
        player.enabled = false;
        obstacleSpawner.enabled = false;

        for(int i = 0; i < gameControls.Length; i++) {
            gameControls[i].SetActive(false);
        }
    }

    public void Play() {
        score = 0;
        player.transform.position = Vector2.zero;
        scoreText.text = "Score:0";
        player.enabled = true;
        obstacleSpawner.enabled = true;
        Time.timeScale = 1f;

        Obsticle[] obsticles = FindObjectsOfType<Obsticle>();
        for (int i = 0; i <  obsticles.Length; i++) {
            Destroy(obsticles[i].gameObject);
        }

        TitleScreen.SetActive(false);

        for(int i = 0; i < gameControls.Length; i++) {
            gameControls[i].SetActive(true);
        }
    }

    public void GameOver() 
    {
        TitleScreen.GetComponentInChildren<Text>().text = "Retry";
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
