using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerController : MonoBehaviour
{
    public GameObject MainAudioSource;
    public GameObject EntryMusicAudioSource;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < 500)
        {
            EntryMusicAudioSource.SetActive(false);
            MainAudioSource.SetActive(true);
        }
    }

    
}
