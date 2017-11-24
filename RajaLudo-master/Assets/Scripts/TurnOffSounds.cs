using UnityEngine;
using UnityEngine.UI;

public class TurnOffSounds : MonoBehaviour {

    [SerializeField] Image _image;
    [SerializeField] AudioSource backgroundMusic;

    void Start()
    {
        _image.enabled = false;
    }

    public void ChangeStatus()
    {
        if (_image.enabled == false)
        {
            _image.enabled = true;
            backgroundMusic.enabled = false;
        }
        else
        {
            backgroundMusic.enabled = true;
            
            _image.enabled = false;
        }
    }
}
