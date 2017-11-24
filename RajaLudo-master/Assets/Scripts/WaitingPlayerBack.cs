using UnityEngine;


public class WaitingPlayerBack : MonoBehaviour {

    public RectTransform MainMenu;   
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
           
            this.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
        }
	}

   
}
