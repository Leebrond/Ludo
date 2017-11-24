
using UnityEngine;


public class playSound : MonoBehaviour {

    bool SoundOn = true;

    public void ChangeSound()
    {
        if (SoundOn)
        {
            SoundOn = false;
            GameManager.instance.Sounds = false;
        }
        else
        {
            SoundOn = true;
            GameManager.instance.Sounds = true;
        }
    }
}
