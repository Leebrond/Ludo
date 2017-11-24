
using UnityEngine;

public class ActiverterHelper : MonoBehaviour {

    public GameObject[] Activeter;
    RandomHelper randomHelper;
   
    public void SetActiveter()
    {
        randomHelper = FindObjectOfType<RandomHelper>();
        randomHelper.PS = Activeter;
        randomHelper.GetActiveter();
    }
}
