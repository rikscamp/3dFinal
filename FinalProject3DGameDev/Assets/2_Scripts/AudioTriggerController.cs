using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerController : MonoBehaviour
{
    public GameObject MainAudioSource;
    public GameObject EntryMusicAudioSource;
    public GameObject Player;
    public AudioSource MainAudio;
    public int PitchDuration = 10;
    public float[] Pitches;
    public int PitchVariable;

    // Start is called before the first frame update
    void Start()
    {
        MainAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //create Array

        Pitches = new float[10];

        Pitches[0] = 0.2f;
        Pitches[1] = 0.4f;
        Pitches[2] = 0.6f;
        Pitches[3] = 0.8f;
        Pitches[4] = 1.0f;
        Pitches[5] = 1.2f;
        Pitches[6] = 1.4f;
        Pitches[7] = 1.6f;
        Pitches[8] = 1.8f;
        Pitches[9] = 2.0f;

        PitchVariable = Random.Range(0, 9);

        //Swap Audio Sources

        if (Player.transform.position.y < 500)
        {
            EntryMusicAudioSource.SetActive(false);
            MainAudioSource.SetActive(true);
            StartCoroutine(PitchChange());
        }
    }

    IEnumerator PitchChange()
    {
        for (int i = 0; i < PitchDuration; i++)
        {
            MainAudio.pitch = PitchVariable;
        }

        yield return new WaitForSeconds(PitchDuration);
    }

}

