using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour
{
    private GameController gameC;
    private GameManager gameM;
    private SpriteRenderer spriteRenderer;
    public Sprite[] numbersSprite;
    private int score = 0;
    public bool P1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameC = GameController.gameController;
        gameM = GameManager.gameManager;
    }

    void Update()
    {
        if (P1)
        {
            score = gameM.Score1;
        } else {
            score = gameM.Score2;
        }

        spriteRenderer.sprite = numbersSprite[score];
    }
}
