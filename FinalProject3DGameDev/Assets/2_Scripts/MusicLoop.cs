using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource[] musicSources;

    public int musicBPM;
    public int timeSignature;
    public int barsLength;

    private float loopPointMinutes;
    private float loopPointSeconds;
    private int nextSource;
    private double time;

    // Start is called before the first frame update
    void Start()
    {
        loopPointMinutes = (barsLength * timeSignature) / musicBPM;

        loopPointSeconds = loopPointMinutes / 60;

        time = AudioSettings.dspTime;

        musicSources[0].Play();
        nextSource = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!musicSources[nextSource].isPlaying)
        {
            time = time + loopPointSeconds;

            musicSources[nextSource].PlayScheduled(time);

            nextSource = 1 - nextSource; //Switches to other AudioSource
        }
    }
}
