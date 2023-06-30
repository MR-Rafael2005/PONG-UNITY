using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            LoadGameL();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            loadOptions();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void loadOptions()
    {
        StartCoroutine(loadOp());
    }

    public void LoadGameL()
    {
        StartCoroutine(load());
    }

    IEnumerator loadOp()
    {
        var loaded = SceneManager.LoadSceneAsync("Options");
        while (loaded.isDone == false)
        {
            yield return null;
        }
    }

    IEnumerator load()
    {
        var loaded = SceneManager.LoadSceneAsync("LoadScreen");
        while(loaded.isDone == false)
        {
            yield return null;
        }
    }
}
