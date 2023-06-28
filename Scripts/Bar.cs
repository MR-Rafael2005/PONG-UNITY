using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bar : MonoBehaviour
{
    private Rigidbody2D body;
    private GameController gameC;
    public float speed;
    public float maxPos;
    public string inputDirection;

    void Start()
    {
        gameC = GameController.gameController;
        body = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if(gameC.paused == false)
        {
            if (Input.GetAxisRaw(inputDirection) < 0 && transform.position.y >= -maxPos)
            {
                body.velocity = new Vector2(0, speed * -1);
            }
            else if (Input.GetAxisRaw(inputDirection) > 0 && transform.position.y <= maxPos)
            {
                body.velocity = new Vector2(0, speed * 1);
            }
            else
            {
                body.velocity = new Vector2(0, 0);
            }
        } else {
            body.velocity = new Vector2(0, 0);
        }
    }
}
