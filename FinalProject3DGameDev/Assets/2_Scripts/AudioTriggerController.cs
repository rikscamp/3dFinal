using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerController : MonoBehaviour
{
    public GameObject MainAudioSource;
    public GameObject EntryMusicAudioSource;
    public GameObject Player;

   // public AudioSource MainAudio;
  
   // public float[] Pitches;
   // public static int Range;
   // public float waitTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
       // MainAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //create Array

        //Pitches = new float[10];

        //Range = Random.Range(0, 9);

        //Swap Audio Sources

        if (Player.transform.position.y < 500)
        {
            EntryMusicAudioSource.SetActive(false);
            MainAudioSource.SetActive(true);
            //StartCoroutine(PitchChange(waitTime));
        }


    }

    //IEnumerator PitchChange(float waitTime)
  //  {
       // for (int i = 0; i < waitTime; i++)
       // {
           // MainAudio.pitch = Range;
       // }

       // yield return new WaitForSeconds(waitTime);
    //}

}

