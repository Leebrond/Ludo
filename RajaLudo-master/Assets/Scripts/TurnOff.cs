using UnityEngine;
using UnityEngine.UI;

public class TurnOff : MonoBehaviour {

    [SerializeField] Image _image;
    [SerializeField] AudioSource backgroundMusic;

	void Start ()
    {        
        _image.enabled = true;
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
            backgroundMusic.Play();
            _image.enabled = false;
        }
    }
}
