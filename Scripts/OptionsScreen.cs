using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScreen : MonoBehaviour
{
    private GameManager gameM;
    public Dropdown dropRes;
    public Text pointsTXT;
    private List<string> resolutions = new List<string>();
    public Button muteBTN;
    public Text muteBTNText;
    public Sprite[] UnMuteImgs; 

    void Start()
    {
        gameM = GameManager.gameManager;

        dropRes.ClearOptions();
        for (int i = 0; i < gameM.resolutionsX.Length; i++)
        {
            resolutions.Add(string.Format("{0} x {1}", gameM.resolutionsX[i], gameM.resolutionY[i]));
        }

        dropRes.AddOptions(resolutions);

        if(gameM.camRefX == 1920)
        {
            dropRes.value = resolutions.Count - 3;
        } 
        else if(gameM.camRefX == 1280)
        {
            dropRes.value = resolutions.Count - 2;
        } 
        else
        {
            dropRes.value = resolutions.Count - 1;
        }

        pointsTXT.text = gameM.pointsToWin.ToString();

        if (AudioListener.volume != 0)
        {
            muteBTN.GetComponent<Image>().sprite = UnMuteImgs[0];
            muteBTNText.text = "MUTE[U]";
        }
        else
        {
            muteBTN.GetComponent<Image>().sprite = UnMuteImgs[1];
            muteBTNText.text = "UNMUTE[U]";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            backTitle();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            UnMuteBTN();
        }

        dropRes.onValueChanged.AddListener(delegate { 
            changeRes(); 
        });
    }

    public void backTitle()
    {
        StartCoroutine(backT());
    }

    public void UnMuteBTN()
    {
        Debug.Log("Pressionado");
        if (AudioListener.volume == 0)
        {
            muteBTN.GetComponent<Image>().sprite = UnMuteImgs[0];
            muteBTNText.text = "MUTE[U]";
            gameM.UnMute();
        }
        else
        {
            muteBTN.GetComponent<Image>().sprite = UnMuteImgs[1];
            muteBTNText.text = "UNMUTE[U]";
            gameM.UnMute();
        }
    }

    public void changeRes()
    {
        string[] resChoice = resolutions[dropRes.value].Split('x');
        int x = Convert.ToInt16(resChoice[0].Trim());
        int y = Convert.ToInt16(resChoice[1].Trim());
        gameM.changeRes(x, y);
    }

    public void upPoints()
    {
        if(gameM.pointsToWin < 9)
        {
            gameM.pointsToWin++;
            pointsTXT.text = gameM.pointsToWin.ToString();
        }
    }

    public void downPoints()
    {
        if (gameM.pointsToWin > 1)
        {
            gameM.pointsToWin--;
            pointsTXT.text = gameM.pointsToWin.ToString();
        }
    }

    IEnumerator backT()
    {
        var loaded = SceneManager.LoadSceneAsync("TitleScreen");
        while (loaded.isDone == false)
        {
            yield return null;
        }
    }
}
