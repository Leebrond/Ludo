public class StartPhoton : Photon.MonoBehaviour
{    
	void OnEnable () {
        PhotonNetwork. ConnectUsingSettings("1.0");  /*ConnectToRegion(CloudRegionCode.au, "1.0");*/       
    }
}
