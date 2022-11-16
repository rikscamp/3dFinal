using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioToPlay;
    public bool hasTriggered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        hasTriggered = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine("PlaySecond");
        }
    }

    IEnumerator PlaySecond()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        for (int i = 0; i <audioToPlay.Length; i++)
        {
            audioSource.PlayOneShot(audioToPlay[i]);
            yield return new WaitUntil(() => audioSource.isPlaying == false);
        }
        StopCoroutine("PlaySecond");
    }
}
