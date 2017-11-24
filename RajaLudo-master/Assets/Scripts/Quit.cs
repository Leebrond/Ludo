using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Quit : MonoBehaviour {

	public void quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            quit();
        }
    }

}
