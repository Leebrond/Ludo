using UnityEngine;
using System.Collections;

public class PortraitMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(wait());
	}

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        DoLeaveRoom();
    }
	public void DoLeaveRoom()
    {
        StopAllCoroutines();
        PhotonNetwork.LeaveRoom();        
        PhotonNetwork.LoadLevel(0);
    }
}
