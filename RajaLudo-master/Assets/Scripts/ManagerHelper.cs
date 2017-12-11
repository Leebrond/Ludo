using UnityEngine;

public class ManagerHelper : MonoBehaviour {

    [SerializeField] RectTransform WaitingForPlayer;
    [SerializeField] RectTransform MainPanel;
    [SerializeField] RectTransform LoginPanel;
    [SerializeField] RectTransform Header;
    [SerializeField] RectTransform MainMenu;
    [SerializeField] RectTransform TwoPlayer;
    [SerializeField] RectTransform HourPlayer;


    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        if(GameManager.instance.IsLogin)
        {
            MainPanel.gameObject.SetActive(true);
            LoginPanel.gameObject.SetActive(false);
            
        }
    }

    public void DoWaitForPlayers()
    {
        TwoPlayer.gameObject.SetActive(false);
        HourPlayer.gameObject.SetActive(false);
        Header.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(true);
        MainPanel.gameObject.SetActive(false);
        WaitingForPlayer.gameObject.SetActive(true);
    }

    public void GetPlayersCount(int count)
    {
        GameManager.instance.CountPlayersInGame = count;
    }
}
