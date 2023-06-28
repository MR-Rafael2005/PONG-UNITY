using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private AudioSource audioSource;
    public AudioClip[] musics; 
    private GameController gameC;
    private GameObject ball;
    private GameObject bar1;
    private GameObject bar2;
    public int Score1 = 0;
    public int Score2 = 0;
    private float timeMusic;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        } 
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (GameController.gameController != null)
        {
            gameC = GameController.gameController;
        }
        audioSource = GetComponent<AudioSource>();
        ball = GameObject.Find("Ball");
        bar1 = GameObject.Find("Bar1");
        bar2 = GameObject.Find("Bar2");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void pointScore1()
    {
        gameC = GameController.gameController;
        Score1++;
        RestartMatch();
        if (Score1 < 5)
        {
            gameC.pointed();
        }
        else
        {
            gameC.Win(true);
        }
    }

    public void pointScore2()
    {
        gameC = GameController.gameController;
        Score2++;
        RestartMatch();
        if(Score2 < 5)
        {
            gameC.pointed();
        } 
        else
        {
            gameC.Win(false);
        }
    }

    public void RestartMatch()
    {
        ball = GameObject.Find("Ball");
        ball.GetComponent<Ball>().ResetVelocity();
        ball.transform.position = new Vector3(0, 0, 0);
    }

    public void RestartAllMatch()
    {
        Score1 = 0;
        Score2 = 0;
        gameC.startNewGame();
    }

    public void RePosition()
    {
        ball = GameObject.Find("Ball");
        ball.GetComponent<Ball>().ResetVelocity();
        bar1 = GameObject.Find("Bar1");
        bar2 = GameObject.Find("Bar2");
        ball.transform.position = new Vector3(0, 0, 0);
        bar1.transform.position = new Vector3(-8.5f, 0, 0);
        bar2.transform.position = new Vector3(8.5f, 0, 0);
    }

    public void playMusic()
    {
        bool m1 = Random.Range(0, 10) > 5;
        if(m1)
        {
            audioSource.clip = musics[0];
        } 
        else
        {
            audioSource.clip = musics[1];
        }

        audioSource.Play();
    }

    public void playCurrentMusic()
    {
        audioSource.pitch = 1;
    }

    public void stopMusic()
    {
        audioSource.pitch = 0;
    }

    public void stopPerMusic() 
    {
        audioSource.Stop();
    }
}
