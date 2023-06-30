using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D body;
    private AudioSource audioSource;
    private GameManager gameM;
    private GameController gameC;
    private GameObject Bar1;
    private GameObject Bar2;
    private float disX1;
    private float disX2;
    private float disY1;
    private float disY2;
    public AudioClip hit;
    public int XMul;
    public int YMul;
    public float ballYSpeed;
    public float ballXSpeed;
    private float ballYSpeedInitial;
    private float ballXSpeedInitial;
    public float maxPosY;
    public float maxPosX;
    public float radius;

    void Start()
    {
        Bar1 = GameObject.Find("Bar1");
        Bar2 = GameObject.Find("Bar2");

        ballXSpeedInitial = ballXSpeed;
        ballYSpeedInitial = ballYSpeed;

        gameC = GameController.gameController;
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        gameM = GameManager.gameManager;

        audioSource.clip = hit;

        XMul = Random.Range(0, 2) < 2 ? -1 : 1;
        YMul = Random.Range(0, 2) < 2 ? -1 : 1;
    }

    void FixedUpdate()
    {
        audioSource.panStereo = transform.position.x > 0 ? 1 : -1;
        Move();
        CheckYColision();
        CheckXColision();
    }

    private void CheckYColision()
    {
        if(body.velocity.magnitude != 0)
        {
            if ((transform.position.y >= maxPosY && YMul > 0) || (transform.position.y <= -maxPosY && YMul < 0))
            {
                YMul *= -1;
                transform.position = new Vector3(transform.position.x, transform.position.y > 0 ? transform.position.y - radius : transform.position.y + radius, transform.position.z);
                ballYSpeed += 0.15f;
            }
        }
    }

    private void CheckXColision()
    {
        if (body.velocity.magnitude != 0)
        {
            float disX1 = (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(Bar1.transform.position.x)) - 0.375f - 0.25f);
            float disX2 = (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(Bar2.transform.position.x)) - 0.375f - 0.25f);

            if(transform.position.y > Bar1.transform.position.y)
            {
                disY1 = (transform.position.y - Bar1.transform.position.y - 1.5f - 0.25f);
            } else {
                disY1 = (Bar1.transform.position.y - transform.position.y - 1.5f - 0.25f);
            }
            
            if(transform.position.y > Bar2.transform.position.y)
            {
                disY2 = (transform.position.y - Bar2.transform.position.y - 1.5f - 0.25f);
            } else {
                disY2 = (Bar2.transform.position.y - transform.position.y - 1.5f - 0.25f);
            }

            if (disX2 <= 0 || disX1 <= 0)
            {
                if((transform.position.x < 0  && XMul < 0 && disY1 <= 0) || (transform.position.x > 0 && XMul > 0 && disY2 <= 0))
                {
                    playHit();
                    XMul *= -1;
                    ballXSpeed += 0.225f;
                    if ((disY1 >= -0.3f && transform.position.x < 0) || (disY2 >= -0.3f && transform.position.x > 0))
                    {
                        if(((transform.position.y < Bar1.transform.position.y && YMul > 0 && transform.position.x < 0) || (transform.position.y > Bar1.transform.position.y && YMul < 0 && transform.position.x < 0)) || ((transform.position.y < Bar2.transform.position.y && YMul > 0 && transform.position.x > 0) || (transform.position.y > Bar2.transform.position.y && YMul < 0 && transform.position.x > 0)))
                        {
                            YMul *= -1;
                        }
                    }
                }
            }

            if (transform.position.x >= maxPosX - radius)
            {
                gameM.pointScore1();
            }
            if (transform.position.x <= -maxPosX + radius)
            {
                gameM.pointScore2();
            }
        }
    }

    private void Move()
    {
        if (gameC.paused == false)
        {
            body.velocity = new Vector2(ballXSpeed * XMul, ballYSpeed * YMul);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
    
    void playHit()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void ResetVelocity()
    {
        ballXSpeed = ballXSpeedInitial;
        ballYSpeed = ballYSpeedInitial;
    }
}
