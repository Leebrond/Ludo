using UnityEngine;

public class PlaySound1 : MonoBehaviour {

    [SerializeField] AudioSource playit;
    [SerializeField] AudioClip ChangeClip;

    void DoIt()
    {        
        playit.Play();
    }

    void DoItAgain()
    {
        playit.clip = ChangeClip;
        playit.Play();
    }
}
