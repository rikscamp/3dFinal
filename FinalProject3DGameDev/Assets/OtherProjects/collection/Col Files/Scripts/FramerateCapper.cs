using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FramerateCapper : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public TMP_Text FPStext;

    private void Awake()
    {
        //Framerate Locks

        //Application.targetFrameRate = 32;
        Application.targetFrameRate = 61;
        //Application.targetFrameRate = 120;

        //Framerate Unlock

        //This may not be doing what i think it should be doing... needs more testing
        //Application.targetFrameRate = -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer += timelapse;

        if (timer <= 0 ) avgFramerate = (int) (1f / timelapse) ;
        FPStext.text = string.Format(display, avgFramerate.ToString());
        
    }
}
