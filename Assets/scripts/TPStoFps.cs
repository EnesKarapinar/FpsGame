using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPStoFps : MonoBehaviour
{

    public Camera FPSCamera;
    public AudioListener FPSaudio;
    public Camera TPSCamera;
    public AudioListener TPSaudio;
    public bool isFPS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            isFPS = !isFPS;
            CheckCamera();
        }
    }

    void CheckCamera()
    {
        if(isFPS)
        {
            FPSCamera.enabled = true;
            FPSaudio.enabled = true;
            TPSCamera.enabled = false;
            TPSaudio.enabled = false;
        }
        else
        {
            FPSCamera.enabled = false;
            FPSaudio.enabled = false;
            TPSCamera.enabled = true;
            TPSaudio.enabled = true;
        }
    }
}
