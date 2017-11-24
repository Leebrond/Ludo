
using UnityEngine;

public class BackButton : MonoBehaviour {

    [SerializeField] GameObject OpenThis;
    [SerializeField] GameObject CloseThis;
	
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenThis.SetActive(true);
            CloseThis.SetActive(false);
        }
	}
}
