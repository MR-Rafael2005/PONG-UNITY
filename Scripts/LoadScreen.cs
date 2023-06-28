using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(loadGame());    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator loadGame()
    {
        yield return new WaitForSeconds(1);
        var loadedG = SceneManager.LoadSceneAsync("Pong");
        while(loadedG.isDone == false)
        {
            yield return null;
        }
    }
}
