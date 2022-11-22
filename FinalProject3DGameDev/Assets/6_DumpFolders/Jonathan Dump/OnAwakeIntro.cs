using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAwakeIntro : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioToPlay;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.PlayOneShot(audioToPlay[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
