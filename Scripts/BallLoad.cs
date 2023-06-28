using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLoad : MonoBehaviour
{
    public float Speed;
    public float maxX;
    public float maxY;
    private int XDir;
    private int YDir;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        XDir = Random.Range(0, 10) < 6 ? 1 : -1;
        YDir = Random.Range(0, 10) < 6 ? 1 : -1;
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(Speed * XDir, Speed * YDir);
        if(transform.position.y >= maxY || transform.position.y <= -maxY)
        {
            YDir *= -1;
            transform.position = new Vector3(transform.position.x, transform.position.y < 0 ? transform.position.y + 0.25f : transform.position.y - 0.25f, 0);
        }

        if(transform.position.x >= maxX || transform.position.x <= -maxX)
        {
            XDir *= -1;
            transform.position = new Vector3(transform.position.x < 0 ? transform.position.x + 0.25f : transform.position.x - 0.25f, transform.position.y, 0);
        }
    }
}
