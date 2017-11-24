using UnityEngine;

public class SreenOrLand : MonoBehaviour {

    public void SetLand()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void OnEnable()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
