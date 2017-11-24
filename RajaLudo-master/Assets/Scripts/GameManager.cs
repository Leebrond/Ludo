using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Photon.MonoBehaviour
{ 

    public static GameManager instance;


    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }



    [SerializeField] GameObject PlayerPrefab;


    public bool IsLogin = false;
    public bool IsGameOver = true;

    public string ID;
    public string FirstName;
    public string LastName;

    public bool BGSound;
    public bool Sounds;

    [SerializeField]
    private string table_id;
    public string TableId{get{return table_id;} set{ table_id = value; }}

    [SerializeField]
    private long balance;
    public long Balance { get { return balance; } set { balance = value; } }

    [SerializeField]
    private int countPlayersInGame;
    public int CountPlayersInGame { get { return countPlayersInGame; } set { countPlayersInGame = value; } }

    [SerializeField]
    private int gameCoust;
    public int GameCoust { get { return gameCoust; } set { gameCoust = value; } }
   
    
    public void DoJoinRoom(string tableID, int entryfee)
    {
        table_id = tableID;
        gameCoust = entryfee;
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
        Debug.Log("Try to connect to random room");
        PhotonNetwork.JoinRandomRoom(null, (byte)countPlayersInGame);
        Button[] buts = FindObjectsOfType<Button>();
        foreach (Button but in buts)
        {
            but.enabled = false;
        }
        
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Button[] buts = FindObjectsOfType<Button>();
        foreach (Button but in buts)
        {
            but.enabled = true;
        }
        Debug.Log("OnPhotonRandomJoinFailed()");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = (byte)countPlayersInGame}, null);
       
    }

   

    public void OnJoinedRoom()
    {
        IsGameOver = false;
        Debug.Log("OnJoinedRoom()");
        FindObjectOfType<ManagerHelper>().DoWaitForPlayers();        
        
    }

    public void OnPhotonPlayerConnected(PhotonPlayer other)
    {

        Debug.Log("OnPhotonPlayerConnected()");
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.room.PlayerCount==PhotonNetwork.room.MaxPlayers)
            {               
                PhotonNetwork.LoadLevel(1);                
            }
        }
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer other)
    {
        Debug.Log("OnPhotonPlayerDisconnected()");
        if (PhotonNetwork.room.PlayerCount == 1 && IsGameOver==false)
        {
            FindObjectOfType<NetworkHelper>().WinGame();
        }        
        else
        {
            FindObjectOfType<NetworkHelper>().DestroyEnemyTokens(other.ID);
        }
    }

    void OnDisconnectedFromPhoton()
    {
        
        if (IsGameOver == false)
        {           
            FindObjectOfType<NetworkHelper>().Loser();
        }
       
    }

   
    private void OnApplicationPause(bool pause)
    {
        if(pause == true)
        {
            if (IsGameOver == false)
            {
                FindObjectOfType<NetworkHelper>().Loser();
            }
        }
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (IsGameOver == false)
            {
                FindObjectOfType<NetworkHelper>().Loser();
            }
        }
    }



    public virtual void OnLeftRoom()
    {
        Debug.Log("OnLeftRoom()");        
        GameCoust = 0;
        CountPlayersInGame = 0;
        IsGameOver = true;
    }

}
