using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraBase : MonoBehaviour
{
    private PixelPerfectCamera perfectCamera;
    private GameManager gameM;

    void Start()
    {
        gameM = GameManager.gameManager;
        perfectCamera = GetComponent<PixelPerfectCamera>(); 
        if (perfectCamera.refResolutionX != gameM.camRefX || perfectCamera.refResolutionY != gameM.camRefY || perfectCamera.assetsPPU != gameM.PPURef)
        {
            Screen.SetResolution(gameM.camRefX, gameM.camRefY, Screen.fullScreen);
            perfectCamera.refResolutionX = gameM.camRefX;
            perfectCamera.refResolutionY = gameM.camRefY;
            perfectCamera.assetsPPU = gameM.PPURef;
        }
    }

    void Update()
    {
        if(perfectCamera.refResolutionX != gameM.camRefX || perfectCamera.refResolutionY != gameM.camRefY || perfectCamera.assetsPPU != gameM.PPURef)
        {
            Screen.SetResolution(gameM.camRefX, gameM.camRefY, Screen.fullScreen);
            perfectCamera.refResolutionX = gameM.camRefX;
            perfectCamera.refResolutionY = gameM.camRefY;
            perfectCamera.assetsPPU = gameM.PPURef;
        }
    }
}
