using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            LoadGameL();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadGameL()
    {
        StartCoroutine(load());
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
