using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerController : MonoBehaviour
{
    public GameObject MainAudioSource;
    public GameObject EntryMusicAudioSource;
    public GameObject Player;
    public AudioSource MainAudio;
  
    public float[] Pitches;
    public static int Range;

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

        Range = Random.Range(0, 9);

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
        for (int i = 0; i < 10; i++)
        {
            MainAudio.pitch = Range;
        }

        yield return new WaitForSeconds(10);
    }

}

