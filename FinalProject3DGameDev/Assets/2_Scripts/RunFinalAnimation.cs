using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFinalAnimation : MonoBehaviour
{
    [SerializeField] private Animator finalAnimaton;
    [SerializeField] private GameObject finalScreen;
    [SerializeField] private GameObject NoCamera;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Island;

    [SerializeField] private string DS_Idle = "DeleteSequenceIdle";
    [SerializeField] private string DS_Play = "DeleteSequence";
    [SerializeField] private string DS_Done = "DeleteSequenceDone";

    public float BeforePlay = 0.0f;
    void OnTriggerEnter(Collider other) //Checks for collison with an object
    {
        if (other.tag == "Player") //If that object has the player tag, run the corountine 
        {
            StartCoroutine(runCutscene());
        }
    }
    
    public IEnumerator runCutscene()
    {
        yield return new WaitForSeconds(5f); //Wait for 5 seconds
        Debug.Log("Running Animation: DeleteSequence"); //Begin the final Animation 
        finalAnimaton.Play(DS_Play, 0, BeforePlay);
        yield return new WaitForSeconds(23f); //DeleteSequence is a little over 23 seconds long, the last second is just the idle animation, this waits until the animation is done, then sets to idle
        Debug.Log("Running Animation: DeleteSequenceDone");
        finalAnimaton.Play(DS_Done, 0, BeforePlay); //Sets Animation to Idle
        Island.SetActive(false); //Disables all of the invisible walls + the island so that Tumblin falls
        yield return new WaitForSeconds(2f); //Wait for 2 second
        finalScreen.SetActive(true); //Enables finale screen
        yield return new WaitForSeconds(7f); //Wait for 1 second
        NoCamera.SetActive(false); //Gets rid of No Camera Sprite
        Credits.SetActive(true); //Enables Credit
    }
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
