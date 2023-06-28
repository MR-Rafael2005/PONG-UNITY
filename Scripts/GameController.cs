using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameManager gameM;
    public static GameController gameController;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip endGame;
    public AudioClip getReady;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip point;
    private bool isLoop;
    public GameObject FrontOBJs;
    public GameObject P1Message;
    public GameObject P2Message;
    public GameObject RESBtn;
    public bool paused;
    public bool animating;
    private bool waiting = false;

    void Start()
    {
        P1Message = GameObject.Find("P1Message");
        P2Message = GameObject.Find("P2Message");
        RESBtn = GameObject.Find("RE_Button");
        gameController = this;
        gameM = GameManager.gameManager;
        gameController = this;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (P1Message != null)
        {
            P1Message.SetActive(false);
        }
        if (P2Message != null)
        {
            P2Message.SetActive(false);
        }
        if (RESBtn != null)
        {
            RESBtn.SetActive(false);
        }
        anim.Play("StartGame");
        animating = true;
    }

    void Update()
    {
        if(!animating && Input.GetButtonDown("Start") && !waiting)
        {
            pause();
        }
        if(waiting && Input.GetButtonDown("Start"))
        {
            ReStartALL();
        }
    }

    public void pointed()
    {
        animating = true;
        pause();
        anim.Play("Pointed");
    }

    public void startNewGame()
    {
        audioSource.Stop();
        waiting = false;
        if (P1Message != null)
        {
            P1Message.SetActive(false);
        }
        if (P2Message != null)
        {
            P2Message.SetActive(false);
        }
        if (RESBtn != null)
        {
            RESBtn.SetActive(false);
        }
        anim.Play("StartGame");
        animating = true;
    }

    public void startGame()
    {
        FrontOBJs.SetActive(true);
        GMPlay();
        anim.Play("NDA");
        animating = false;
    }

    public void pause()
    {
        if (!paused)
        {
            paused = true;
            if (!animating) 
            {
                gameM.stopMusic();
            }
        } else {
            gameM.playCurrentMusic();
            paused = false;
        }
    }

    public void ReStart()
    {
        animating = false;
        anim.Play("NDA");
        pause();
    }

    public void Win(bool p1)
    {
        gameM.RePosition();
        gameM.stopPerMusic();
        playEnd();
        waiting = true;
        if (p1)
        {
            FrontOBJs.SetActive(false);
            P1Message.SetActive(true);
            RESBtn.SetActive(true);
        } else {
            FrontOBJs.SetActive(false);
            P2Message.SetActive(true);
            RESBtn.SetActive(true);
        }
    }

    public void ReStartALL()
    {
        gameM.RestartAllMatch();
    }

    public void playGetReady()
    {
        audioSource.clip = getReady;
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void playPointed()
    {
        audioSource.clip = point;
        float vol = audioSource.volume;
        audioSource.volume = 0.9f;
        audioSource.PlayOneShot(audioSource.clip);
        audioSource.volume = vol;
    }

    public void playEnd()
    {
        audioSource.clip = endGame;
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void GMPlay()
    {
        audioSource.Stop();
        gameM.playMusic();
    }
}
